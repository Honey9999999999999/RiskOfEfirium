using Architecture;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class InventoryInteractor : Interactor
    {
        private Inventory _inventory;

        private Dictionary<NamesOfDrop, Action> _addDropMap;

        public void AddItem(NamesOfDrop nameOfDrop)
        {
            _addDropMap[nameOfDrop]?.Invoke();
        }

        public override void Initialize()
        {
            base.Initialize();

            _inventory = new();

            _addDropMap = new()
            {
                [NamesOfDrop.AlienResources] = () => _inventory.AddResource(NamesOfDrop.AlienResources),
                [NamesOfDrop.ElectricResources] = () => _inventory.AddResource(NamesOfDrop.ElectricResources),
                [NamesOfDrop.MechanicalResources] = () => _inventory.AddResource(NamesOfDrop.MechanicalResources),

                [NamesOfDrop.MoveMod] = () => _inventory.AddItem<MoveMod>(),
            };
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
