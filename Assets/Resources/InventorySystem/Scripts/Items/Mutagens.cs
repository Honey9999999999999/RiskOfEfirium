using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;

namespace Assets.Resources.InventorySystem.Scripts.Items
{
    public class Mutagens : Item
    {
        public override ItemNames Name => ItemNames.Mutagens;
        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.Health] = .05f
        };
    }
}