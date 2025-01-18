using Architecture;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    [RequireComponent(typeof(LivingEntity))]
    public class EnemyLootSpawner : MonoBehaviour
    {
        [SerializeField] private NamesOfEnemies enemyName;
        [SerializeField] private int _countMaxLoot;

        private const float FORCE = 5;
        private LivingEntity _entity;

        private void Start()
        {
            _entity = GetComponent<LivingEntity>();
            _entity.OnEntityDeath += SpawnLoot;
        }

        private void SpawnLoot()
        {
            LootInteractor lootInteractor = Game.GetInteractor<LootInteractor>();
            for (int i = 0; i < _countMaxLoot; i++)
            {
                lootInteractor.SpawnLoot(enemyName, transform).
                    GetComponent<Rigidbody>().
                    AddForce((Vector3.up + new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f))) * FORCE, ForceMode.Impulse);
            }
        }
    }
}
