using Architecture;
using Assets.Scripts.InventorySystem.Items;

namespace Assets.Scripts.InventorySystem
{
    public class InventoryInteractor : Interactor
    {
        private Inventory _inventory;

        public void AddItem<TItem>() where TItem : Item
        {
            _inventory.AddItem<TItem>();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            _inventory = new();
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
