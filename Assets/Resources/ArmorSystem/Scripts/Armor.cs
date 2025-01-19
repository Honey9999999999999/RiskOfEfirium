using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;

namespace Assets.Resources.ArmorSystem.Scripts
{
    public class Armor
    {
        private readonly Dictionary<TypeDamage, float> resistanceMap;

        public Armor(CharacterCharacteristicCard ccc)
        {
            resistanceMap = new()
            {

                [TypeDamage.Thermal] = ccc.GetValueOf(Characteristics.ThermalResistance),
                [TypeDamage.Mechanical] = ccc.GetValueOf(Characteristics.MechanicalResistance)
            };

            ccc.Get(Characteristics.ThermalResistance).OnCharacteristicChanged += 
                (float value) => resistanceMap[TypeDamage.Thermal] = value;
            ccc.Get(Characteristics.MechanicalResistance).OnCharacteristicChanged += 
                (float value) => resistanceMap[TypeDamage.Mechanical] = value;
        }

        public float Reduce(TypeDamage type, float damage)
        {
            return damage - damage * resistanceMap[type];
        }
    }
}
