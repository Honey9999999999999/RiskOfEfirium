using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;

namespace Assets.Resources.InventorySystem.Scripts.Items
{
    public class LightCapacitor : Item
    {
        public override ItemNames Name => ItemNames.LightCapacitor;
        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.AreaOfLight] = .05f
        };
    }
}