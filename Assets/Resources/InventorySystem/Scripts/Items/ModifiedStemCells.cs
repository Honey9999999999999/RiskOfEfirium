
using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;

namespace Assets.Resources.InventorySystem.Scripts.Items
{
    public class ModifiedStemCells : Item
    {
        public override ItemNames Name => ItemNames.ModifiedStemCells;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.Regeneration] = .05f
        };
    }
}