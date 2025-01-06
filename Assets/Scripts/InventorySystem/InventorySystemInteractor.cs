using Architecture;
using Assets.Scripts.Tools;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    public class InventorySystemInteractor : Interactor
    {
        //public Inventory PlayerInventory { get; private set; }
        public ItemInformationMap ItemInformationCard { get; private set; }

        private const string PATH_TO_UIINTERACTOR = "Prefabs/InventorySystem/UIInventory";

        public override void Initialize()
        {
            base.Initialize();            
        }
        public override void OnCreate()
        {
            base.OnCreate();

            ItemInformationCard = new();
            UIInventory uIInventory = ResourceLoader.Load<UIInventory>
                (
                    PATH_TO_UIINTERACTOR,
                    Game.GetInteractor<UICanvasIntaractor>().uiCanvas.transform
                );

            Item.OnResourceAmountChanged += uIInventory.ChangeCountValue;
        }

        public override void OnStart()
        {
            base.OnStart();


        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
