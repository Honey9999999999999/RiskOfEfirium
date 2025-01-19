using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;

namespace Assets.Resources.InventorySystem.Scripts.Items
{
    public class ArmoredPads : Item
    {
        public override ItemNames Name => ItemNames.ArmoredPads;

        public override Dictionary<Characteristics, float> ImprovedCharacteristicsMap => improvedCharacteristicsMap;
        private Dictionary<Characteristics, float> improvedCharacteristicsMap = new()
        {
            [Characteristics.MechanicalResistance] = 0.05f,
            [Characteristics.Movespeed] = -0.05f
        };
    }
}