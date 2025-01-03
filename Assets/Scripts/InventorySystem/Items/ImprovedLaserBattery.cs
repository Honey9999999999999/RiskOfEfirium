using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem.Items
{
    internal class ImprovedLaserBattery : Item
    {
        public override NamesOfDrop Name => NamesOfDrop.ImprovedLaserBattery;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private readonly Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.MaxAmmo] = 0.15f
        };

        public ImprovedLaserBattery(CharacterCharacteristicCard personalCCC) : base(personalCCC) { }
    }
}
