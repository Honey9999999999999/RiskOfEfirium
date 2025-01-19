using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;

namespace Assets.Scripts.InventorySystem
{
    public class SyneticMuscles : Item
    {
        public override ItemNames Name => ItemNames.SyneticMuscles;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private readonly Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.Movespeed] = 0.1f
        };
    }
}
