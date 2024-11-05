using Assets.Scripts.InventorySystem;
using System.Collections.Generic;

namespace Assets.Scripts.CraftSystem.Blueprints
{
    public class ThermostatBlueprint : Blueprint
    {
        public override WorkBenchType WorkBenchType => WorkBenchType.Armory;
        public override NamesOfDrop ItemName => NamesOfDrop.Thermostat;
        public override Dictionary<NamesOfDrop, int> Components => _components;
        

        private readonly Dictionary<NamesOfDrop, int> _components = new()
        {
            [NamesOfDrop.MechanicalResources] = 2,
            [NamesOfDrop.ElectricResources] = 2
        };
    }
}
