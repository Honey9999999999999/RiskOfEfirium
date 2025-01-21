using System.Collections.Generic;
using Architecture;
using Assets.Scripts.Entities;
using Assets.Scripts.InputManager;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class LootContainer : MonoBehaviour
{
    public enum TypeSpawn
    {
        Item,
        Room,
        Enemy
    }

    public UnityEvent<DropItem> OnDroped;
    public UnityEvent OnOpened;

    public TypeSpawn typeSpawn;

    public ItemNames itemName;
    public RoomType roomType;
    public NamesOfEnemies enemyName;

    [Min(1)] public int lootAmount = 1;
    [Min(1)] public int openAmount = 1;

    public bool isRandomazeLootAmount;

    private LootInteractor lootInteractor;

    private delegate DropItem OnSpawn();
    private Dictionary<TypeSpawn, OnSpawn> spawnsMap;

    private bool isOpened;

    private void Start()
    {
        spawnsMap = new()
        {
            [TypeSpawn.Item] = () => lootInteractor.SpawnLoot(itemName, transform.position, transform),
            [TypeSpawn.Room] = () => lootInteractor.SpawnLoot(roomType, transform),
            [TypeSpawn.Enemy] = () => lootInteractor.SpawnLoot(enemyName, transform)
        };

        if (Game.sceneManager.isLoading)
        {
            Game.sceneManager.OnSceneLoaded += (Scene _) => lootInteractor = Game.GetInteractor<LootInteractor>();
            return;
        }

        lootInteractor = Game.GetInteractor<LootInteractor>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger && other.TryGetComponent<Player>(out _))
        {
            InputHandler.OnInteractionButtonInput += OpenContainer;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.isTrigger && other.TryGetComponent<Player>(out _))
        {
            InputHandler.OnInteractionButtonInput -= OpenContainer;
        }
    }

    private void OpenContainer()
    {
        if (!isOpened)
        {
            int lootCounter = isRandomazeLootAmount ? Random.Range(1, lootAmount) : lootAmount;

            for (int i = 0; i < lootCounter; i++)
            {
                DropItem item = spawnsMap[typeSpawn]?.Invoke();
                OnDroped?.Invoke(item);
            }            

            openAmount--;

            if(openAmount <= 0)
            {
                isOpened = true;
                OnOpened?.Invoke();            
            }            
        }
    }
}
