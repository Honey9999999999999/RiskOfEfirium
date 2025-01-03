using Architecture;
using Assets.Scripts.Tools;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    public class InventorySystemInteractor : Interactor
    {
        public Inventory PlayerInventory { get; private set; }
        public ItemInformationMap ItemInformationCard { get; private set; }

        private const string PATH_TO_UIINTERACTOR = "Prefabs/InventorySystem/UIInventory";
        public readonly Dictionary<Tier, Color32> FrameColorMap = new()
        {
            [Tier.Common] = new Color32(255, 255, 255, 255),
            [Tier.Uncommon] = new Color32(0, 255, 0, 255),
            [Tier.Rare] = new Color32(255, 0, 0, 255),
            [Tier.Legendary] = new Color32(255, 201, 14, 255)
        };

        public override void Initialize()
        {
            base.Initialize();

            PlayerInventory = Game.GetInteractor<PlayerInteractor>().player.Inventory;
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
