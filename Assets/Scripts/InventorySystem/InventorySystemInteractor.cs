using Architecture;
using Assets.Scripts.Tools;
using Assets.Scripts.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    public class InventorySystemInteractor : Interactor
    {
        public Inventory Inventory { get; private set; }
        public ItemInformationCard ItemInformationCard { get; private set; }        

        private const string PATH_TO_UIINTERACTOR = "Prefabs/InventorySystem/UIInventory";
        private readonly Dictionary<Tier, string> _frameMap = new()
        {
            [Tier.Common] = "Sprites/InventorySystem/Frames/CommonFrame",
            [Tier.Uncommon] = "Sprites/InventorySystem/Frames/UnCommonFrame",
            [Tier.Rare] = "Sprites/InventorySystem/Frames/RareFrame",
            [Tier.Legendary] = "Sprites/InventorySystem/Frames/LegendaryFrame"
        };

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

        public Sprite GetSpriteFrame(Tier tier) => Resources.Load<Sprite>(_frameMap[tier]);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
