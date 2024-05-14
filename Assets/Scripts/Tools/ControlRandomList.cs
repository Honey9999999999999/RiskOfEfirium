using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tools
{    
    public class ControlRandomList <T>
    {
        private class ControlRandomValue
        {
            public ControlRandomValue(float chance, T value)
            {
                defaultChance = chance;
                this.chance = chance;
                this.value = value;
            }

            public float defaultChance { get; }
            public float chance { get; set; }
            public T value { get; set; }
        }

        private List<ControlRandomValue> controlRandomValues;

        public ControlRandomList()
        {
            controlRandomValues = new();
        }

        public T GetValue()
        {
            float chance = Random.Range(0f, 1f);

            float summChance = 0;

            foreach (var crValue in controlRandomValues)
            {
                summChance += crValue.chance;

                if (summChance >= chance)
                {
                    return crValue.value;
                }
            }

            throw new System.Exception("Imposible chance");
        }

        public void Add(float chance, T value)
        {
            controlRandomValues.Add(new(chance, value));

            UpdateChances();
        }

        private void UpdateChances()
        {
            float summ = 0;

            foreach (var crValue in controlRandomValues)
            {
                summ += crValue.defaultChance;
            }

            foreach (var crValue in controlRandomValues)
            {
                crValue.chance = crValue.defaultChance / summ;
            }
        }
    }
}
