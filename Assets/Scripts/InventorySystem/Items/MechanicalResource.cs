using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class MechanicalResource : Item
    {
        public MechanicalResource() : base(null)
        {
        }

        public override NamesOfDrop Name => NamesOfDrop.MechanicalResources;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => throw new System.NotImplementedException();

        public override void Effect() { }
        public override void ReverseEffect() { }
    }
}
