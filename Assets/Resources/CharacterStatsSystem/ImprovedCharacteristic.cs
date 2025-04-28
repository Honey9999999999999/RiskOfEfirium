using System;
using System.Collections.Generic;
using Assets.Resources.CharacterStatsSystem;
using UnityEngine;

namespace Assets.Scripts.CharacterStatsSystem
{
    public class ImprovedCharacteristic
    {
        public event Action<float> OnCharacteristicChanged;

        private Dictionary<BuffType, Buff> buffMap = new()
        {
            [BuffType.Buff] = new(),
            [BuffType.DeBuff] = new()
        };

        public float CurrentValue
        {
            get =>
                currentValue
                - (currentValue * buffMap[MinValue < MaxValue ? BuffType.DeBuff : BuffType.Buff].Value)
                + (currentValue * buffMap[MinValue < MaxValue ? BuffType.Buff : BuffType.DeBuff].Value);
            private set => currentValue = value;
        }
        private float currentValue;
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

            buffMap[BuffType.Buff].OnChanged += () => OnCharacteristicChanged?.Invoke(CurrentValue);
            buffMap[BuffType.DeBuff].OnChanged += () => OnCharacteristicChanged?.Invoke(CurrentValue);
        }

        public void SetBuff(BuffType type, float procent, float time)
        {
            buffMap[type].SetBuff(procent, time);
        }

        public void Change(float percent)
        {
            float newIndex = index + percent;

            if (IsOutOfBounds(newIndex))
            {
                throw new Exception($"The permissible values ​​of the characteristic are exceeded. Value : {newIndex}");
            }

            Index = newIndex;

            OnCharacteristicChanged?.Invoke(CurrentValue);
        }

        private bool IsOutOfBounds(float index)
        {
            return index < 0 || index > 1;
        }
    }
}
