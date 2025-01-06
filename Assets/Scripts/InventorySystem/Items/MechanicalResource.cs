using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class MechanicalResource : Item
    {
        public override ItemNames Name => ItemNames.MechanicalResources;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => throw new System.NotImplementedException();

        public override void Effect(CharacterCharacteristicCard personalCCC)
        {
        }

        public override void ReverseEffect(CharacterCharacteristicCard personalCCC)
        {
        }
    }
}
