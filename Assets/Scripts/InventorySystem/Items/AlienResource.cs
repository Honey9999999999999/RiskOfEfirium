using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public sealed class AlienResource : Item
    {
        public AlienResource() : base(null)
        {
        }

        public override NamesOfDrop Name => NamesOfDrop.AlienResources;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => throw new System.NotImplementedException();

        public override void Effect() { }
        public override void ReverseEffect() { }
    }
}
