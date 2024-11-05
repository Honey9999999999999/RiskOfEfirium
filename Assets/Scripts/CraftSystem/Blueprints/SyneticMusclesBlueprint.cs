using Assets.Scripts.InventorySystem;
using System.Collections.Generic;

namespace Assets.Scripts.CraftSystem.Blueprints
{
    public class SyneticMusclesBlueprint : Blueprint
    {
        public override WorkBenchType WorkBenchType => WorkBenchType.Medical;

        public override NamesOfDrop ItemName => NamesOfDrop.SyneticMuscles;

        public override Dictionary<NamesOfDrop, int> Components => _components;
        private readonly Dictionary<NamesOfDrop, int> _components = new()
        {
            [NamesOfDrop.AlienResources] = 3,
            [NamesOfDrop.MechanicalResources] = 1,
            [NamesOfDrop.ElectricResources] = 1
        };
    }
}
