using Architecture;
using Assets.Scripts.Tools;
using Assets.Scripts.UI.Inventory;
using Assets.Scripts.UI;

namespace Assets.Scripts.InventorySystem
{
    public class InventorySystemInteractor : Interactor
    {
        public Inventory Inventory { get; private set; }
        public ItemInformationCard ItemInformationCard { get; private set; }
        private const string PATH_TO_UIINTERACTOR = "Prefabs/UI/UIInventory";

        public override string ToString()
        {
            return base.ToString();
        }

        public void AddItem(NamesOfDrop dropName)
        {
            Inventory.AddItem(dropName);
        }

        public override void Initialize()
        {
            base.Initialize();

            Inventory = new();
            ItemInformationCard = new();

            UIInventory uIInventory = ResourceLoader.Load<UIInventory>
                (
                    PATH_TO_UIINTERACTOR, 
                    Game.GetInteractor<UICanvasIntaractor>().uiCanvas.transform
                );
            Item.OnResourceAmountChanged += uIInventory.ChangeCountValue;
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
