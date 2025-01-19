using System.Collections.Generic;
using Architecture;

namespace Assets.Scripts.Spawn
{
    public class EntitySpawnInteractor : Interactor
    {
        private List<EnemySpawner> enemySpawners;

        public override void OnCreate()
        {
            base.OnCreate();

            enemySpawners = new();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnStart()
        {
            base.OnStart();

            SpawnEnemies();
        }

        public void SpawnEnemies()
        {
            foreach (var enemySpawner in enemySpawners)
            {
                enemySpawner.Spawn();
            }
        }

        public void AddEnemySpawner(EnemySpawner enemySpawner) => enemySpawners.Add(enemySpawner);
    }
}
