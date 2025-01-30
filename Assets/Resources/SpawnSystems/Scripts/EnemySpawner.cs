using System.Collections.Generic;
using Architecture;
using UnityEngine;

namespace Assets.Scripts.Spawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] List<Transform> _spawnPoints = new();
        [SerializeField] Enemy enemy;

        void Awake()
        {
            Game.GetInteractor<EntitySpawnInteractor>().AddEnemySpawner(this);
        }

        public void Spawn()
        {
            foreach (Transform spawnPoint in _spawnPoints)
            {
                GameObject newEnemy = GameObject.Instantiate(enemy.gameObject, transform);
                newEnemy.transform.position = spawnPoint.position;
                newEnemy.name = newEnemy.name + Random.value;
            }
        }
    }
}
