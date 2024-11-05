using Assets.Scripts.InventorySystem;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.CraftSystem.Blueprints
{
    internal class ImprovedLaserBatteryBlueprint : Blueprint
    {
        public override WorkBenchType WorkBenchType => WorkBenchType.Armory;

        public override NamesOfDrop ItemName => NamesOfDrop.ImprovedLaserBattery;

        public override Dictionary<NamesOfDrop, int> Components => _components;
        private readonly Dictionary<NamesOfDrop, int> _components = new()
        {
            [NamesOfDrop.MechanicalResources] = 2,
            [NamesOfDrop.ElectricResources] = 1
        };
    }
}
