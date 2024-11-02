using Architecture;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Loot.Config;
using Assets.Scripts.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Loot
{
    public class LootSpawner : MonoBehaviour
    {
        [SerializeField] private RoomType _type;
        [SerializeField] private RoomLootConfig _config = new TestLootConfig();

        [SerializeField] private List<Transform> _spawnPosits = new();

        void OnEnable()
        {
            Game.GetInteractor<NavMeshInteractor>().OnInitialized += SpawnLoot;
        }

        public void SpawnLoot()
        {
            foreach (Transform spawnPoint in _spawnPosits)
            {
                LootInteractor lootInteractor = Game.GetInteractor<LootInteractor>();
                GameObject drop = ResourceLoader.Load<GameObject>(lootInteractor.GetPathToDrop(_config.GetSpawnItem(_type)), transform);
                drop.transform.position = spawnPoint.position;
            }
        }
    }
}
