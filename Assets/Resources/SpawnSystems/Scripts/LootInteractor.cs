using Architecture;
using Assets.Scripts.Entities;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    internal class LootInteractor : Interactor
    {
        public const string PATH_TO_DROP = "InventorySystem/Prefabs/DropItems/TestDrop";

        private DropListsConfig _configDropList;
        private RoomLootConfig _configRoomLoot;
        private DropItemsInfo _linksToDrop;


        public override void Initialize()
        {
            base.Initialize();

            _configDropList = new DropListsSimpleConfig();
            _configRoomLoot = new RoomLootConfigExample();
            _linksToDrop = new DropItemInfoSimple();
        }

        public DropItem SpawnLoot(NamesOfEnemies enemyName, Transform transform)
        {
            return SpawnLoot(_configDropList.GetDropName(enemyName), transform.position);
        }
        public DropItem SpawnLoot(RoomType roomType, Transform transform)
        {
            return SpawnLoot(_configRoomLoot.GetSpawnItem(roomType), transform.position, transform);
        }
        public DropItem SpawnLoot(ItemNames dropName, Vector3 position, Transform parent = null)
        {
            DropItem drop = ResourceLoader.Load<DropItem>(PATH_TO_DROP, parent);
            ResourceLoader.Load<GameObject>(_linksToDrop.GetPathToDrop(dropName), drop.transform);
            drop.DropName = dropName;
            drop.transform.position = position;

            return drop;
        }
    }
}
