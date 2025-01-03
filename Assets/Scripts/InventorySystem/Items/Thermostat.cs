using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem.Items
{
    public class Thermostat : Item
    {
        public Thermostat(CharacterCharacteristicCard personalCCC) : base(personalCCC)
        {
        }

        public override NamesOfDrop Name => NamesOfDrop.Thermostat;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private readonly Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.RateFirePerMin] = 0.1f
        };
    }
}
