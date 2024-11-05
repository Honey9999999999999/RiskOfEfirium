using Architecture;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.Tools;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class UIInventoryInteractor : Interactor
    {
        private const string PATH_TO_UIINTERACTOR = "Prefabs/UI/UIInventory";

        private Transform uiCanvas;

        public override void Initialize()
        {
            base.Initialize();

            uiCanvas = Game.GetInteractor<UICanvasIntaractor>().uiCanvas.transform;

            UIInventory uIInventory = ResourceLoader.Load<UIInventory>(PATH_TO_UIINTERACTOR, uiCanvas);
            Item.OnResourceAmountChanged += uIInventory.ChangeCountValue;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
