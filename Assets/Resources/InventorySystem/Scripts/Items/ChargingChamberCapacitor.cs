using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;

namespace Assets.Scripts.InventorySystem.Items
{
    public class ChargingChamberCapacitor : Item
    {
        public override ItemNames Name => ItemNames.ChargingChamberCapacitor;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private readonly Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.Damage] = 0.05f
        };
    }
}
