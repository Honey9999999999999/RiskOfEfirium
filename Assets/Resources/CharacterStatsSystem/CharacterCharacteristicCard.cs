using System.Collections.Generic;

namespace Assets.Scripts.CharacterStatsSystem
{
    public abstract class CharacterCharacteristicCard
    {
        protected readonly Dictionary<Characteristics, ImprovedCharacteristic> characteristicsMap = new()
        {
            [Characteristics.RateFirePerMin] = new ImprovedCharacteristic(45, 30, 240),
            [Characteristics.MaxAmmo] = new ImprovedCharacteristic(15, 6, 60),
            [Characteristics.ReloadTime] = new ImprovedCharacteristic(4, 6, 0.5f),
            [Characteristics.Damage] = new ImprovedCharacteristic(4, 2, 10),

            [Characteristics.Movespeed] = new ImprovedCharacteristic(4, 0.5f, 10)
        };

        public float GetIndexOf(Characteristics name) => characteristicsMap[name].Index;
        public float GetValueOf(Characteristics name) => characteristicsMap[name].CurrentValue;
        public ImprovedCharacteristic Get(Characteristics name) => characteristicsMap[name];
        public void ChangeOf(Characteristics name, float percent) => characteristicsMap[name].Change(percent);
    }
}
