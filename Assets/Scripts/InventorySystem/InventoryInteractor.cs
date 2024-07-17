using Architecture;
using Assets.Scripts.InventorySystem.DropSystem;
using Assets.Scripts.InventorySystem.Items;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.InventorySystem
{
    public class InventoryInteractor : Interactor
    {
        private static Inventory _inventory;

        private Dictionary<NamesOfDrop, Action> _addDropMap = new()
        {
            [NamesOfDrop.AlienResources] = () => _inventory.AddItem<MoveMod>()
        };

        public void AddItem(NamesOfDrop nameOfDrop)
        {
            _addDropMap[nameOfDrop]?.Invoke();
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
