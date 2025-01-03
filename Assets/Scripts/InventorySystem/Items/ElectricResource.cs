using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class ElectricResource : Item
    {
        public ElectricResource() : base(null)
        {
        }

        public override NamesOfDrop Name => NamesOfDrop.ElectricResources;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => throw new System.NotImplementedException();

        public override void Effect() { }
        public override void ReverseEffect() { }
    }
}
