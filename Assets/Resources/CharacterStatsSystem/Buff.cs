using System;
using MyTimer;
using UnityEngine;

namespace Assets.Resources.CharacterStatsSystem
{
    public class Buff
    {
        public event Action OnChanged;

        public float Value => value;
        private float value;
        private Timer timer;

        public Buff()
        {
            timer = new Timer();
            timer.OnStoped += () => { value = 0; OnChanged?.Invoke(); };
        }

        public void SetBuff(float value, float time)
        {
            value = Mathf.Clamp(value, 0, 1);

            this.value = value > this.value ? value : this.value;

            if (time > timer.GetValue())
            {
                timer.Start(time);
                OnChanged?.Invoke();
            }
        }
    }
}