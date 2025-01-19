using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;

namespace Assets.Scripts.InventorySystem.Items
{
    internal class ImprovedLaserBattery : Item
    {
        public override ItemNames Name => ItemNames.ImprovedLaserBattery;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private readonly Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.MaxAmmo] = 0.15f
        };
    }
}
