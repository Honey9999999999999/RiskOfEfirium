using System.Collections.Generic;

namespace Assets.Scripts.CharacterStatsSystem
{
    public class CharacterCharacteristicCard
    {
        protected Dictionary<Characteristics, ImprovedCharacteristic> characteristicsMap = new()
        {
            [Characteristics.RateFirePerMin] = new ImprovedCharacteristic(45, 30, 240),
            [Characteristics.MaxAmmo] = new ImprovedCharacteristic(15, 6, 60),
            [Characteristics.ReloadTime] = new ImprovedCharacteristic(4, 6, 0.5f),
            [Characteristics.Damage] = new ImprovedCharacteristic(4, 2, 10),

            [Characteristics.Movespeed] = new ImprovedCharacteristic(4, 0.5f, 10),
            [Characteristics.Health] = new ImprovedCharacteristic(100, 60, 300),
            [Characteristics.Regeneration] = new ImprovedCharacteristic(1, 0.2f, 20),
            [Characteristics.Oxygen] = new ImprovedCharacteristic(20, 20, 120),

            [Characteristics.AreaOfLight] = new ImprovedCharacteristic(32, 18, 96),
            [Characteristics.ThermalResistance] = new ImprovedCharacteristic(0.15f, 0.01f, 0.8f),
            [Characteristics.MechanicalResistance] = new ImprovedCharacteristic(0.05f, 0.01f, 0.8f)
        };

        public float GetIndexOf(Characteristics name) => characteristicsMap[name].Index;
        public float GetValueOf(Characteristics name) => characteristicsMap[name].CurrentValue;
        public ImprovedCharacteristic Get(Characteristics name) => characteristicsMap[name];
        public void ChangeOf(Characteristics name, float percent) => characteristicsMap[name].Change(percent);

        public CharacterCharacteristicCard Clone()
        {
            CharacterCharacteristicCard cloneCard = new()
            {
                characteristicsMap = new Dictionary<Characteristics, ImprovedCharacteristic>(characteristicsMap)
            };

            return cloneCard;
        }
    }
}
