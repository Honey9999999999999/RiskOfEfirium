using Architecture;
using Assets.Scripts.Tools;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
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
