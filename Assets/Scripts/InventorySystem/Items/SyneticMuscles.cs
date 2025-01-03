using Assets.Scripts.CharacterStatsSystem;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class SyneticMuscles : Item
    {
        public SyneticMuscles(CharacterCharacteristicCard personalCCC) : base(personalCCC)
        {
        }

        public override NamesOfDrop Name => NamesOfDrop.SyneticMuscles;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private readonly Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.Movespeed] = 0.1f
        };
    }
}
