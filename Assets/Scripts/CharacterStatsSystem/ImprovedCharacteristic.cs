using System;
using UnityEngine;

namespace Assets.Scripts.CharacterStatsSystem
{
    public class ImprovedCharacteristic
    {
        public float CurrentValue { get; private set; }
        public float StockValue { get; }
        public float MinValue { get; }
        public float MaxValue { get; }
        public float Index
        {
            get { return index; }
            private set
            {
                index = value;
                CurrentValue = Mathf.Lerp(MinValue, MaxValue, index);
            }
        }
        private float index;

        public ImprovedCharacteristic(float stockValue, float minValue, float maxValue)
        {
            StockValue = Mathf.Clamp(stockValue, minValue, maxValue);
            MinValue = minValue;
            MaxValue = maxValue;

            Index = (StockValue - minValue) / (maxValue - minValue);
        }

        public void Change(float percent)
        {
            float newIndex = index + percent;

            Debug.Log($"Coming {newIndex} index");

            if (IsOutOfBounds(newIndex))
            {
                throw new Exception($"The permissible values ​​of the characteristic are exceeded. Value : {newIndex}");
            }

            Index = newIndex;
        }

        private bool IsOutOfBounds(float index)
        {
            return index < 0 || index > 1;
        }
    }
}
