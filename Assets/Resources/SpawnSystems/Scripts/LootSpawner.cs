using System.Collections.Generic;
using Architecture;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Scripts.Loot
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private RoomType _type;
        [SerializeField] private List<Transform> _spawnPosits = new();

        void OnEnable()
        {
            Game.GetInteractor<NavMeshInteractor>().OnInitialized += SpawnLoot;
        }

        public void SpawnLoot()
        {
            LootInteractor lootInteractor = Game.GetInteractor<LootInteractor>();

            foreach (Transform spawnPoint in _spawnPosits)
            {
                lootInteractor.SpawnLoot(_type, spawnPoint);
            }
        }
    }
}
