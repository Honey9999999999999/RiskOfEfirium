using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;

namespace Assets.Scripts.InventorySystem
{
    public sealed class AlienResource : Item
    {
        public override ItemNames Name => ItemNames.AlienResources;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => throw new System.NotImplementedException();

        public override void Effect(CharacterCharacteristicCard personalCCC)
        {
        }

        public override void ReverseEffect(CharacterCharacteristicCard personalCCC)
        {
        }
    }
}
