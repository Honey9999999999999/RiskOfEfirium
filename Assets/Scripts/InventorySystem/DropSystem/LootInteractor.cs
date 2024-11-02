using Architecture;
using Assets.Scripts.Entities;

namespace Assets.Scripts.InventorySystem
{
    internal class LootInteractor : Interactor
    {
        private DropListsConfig _config;
        private DropItemsInfo _dropInfo;

        public NamesOfDrop GetDropName(NamesOfEnemies enemyName)
        {
            return _config._dropListsMap[enemyName].GetValue();
        }
        public string GetPathToDrop(NamesOfDrop nameOfDrop)
        {
            return _dropInfo._dropMap[nameOfDrop];
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            _config = new DropListsSimpleConfig();
            _dropInfo = new DropItemInfoSimple();
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
