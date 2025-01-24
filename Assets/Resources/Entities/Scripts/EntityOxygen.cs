using System;
using System.Collections;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using Assets.Scripts.LabyrinthGenerator;
using CoroutineManager;
using UnityEngine;

namespace Assets.Resources.Entities.Scripts
{
    public class EntityOxygen
    {
        public event Action<float> OnOxygenDown;
        public event Action OnOxygenDamaged;
        public event Action OnOxygenRestore;
        public event Action OnOxygenRestored;

        private float _passiveRegenerationPerSec = 4;        
        private bool isOxygen = true;

        private readonly ImprovedCharacteristic oxygenChar;

        private Coroutine oxygenCoroutine;

        public EntityOxygen(LivingEntity entity)
        {
            oxygenChar = entity.PersonalCCC.Get(Characteristics.Oxygen);
            MaxOxygen = oxygenChar.CurrentValue;
            CurrentOxygen = oxygenChar.MinValue;

            PlayerTransition.OnPositionChanged += (Room room) => IsOxygen = room.presenceOfOxygen;
            entity.OnEntityDeath += OnDisable;
        }

        public float CurrentOxygen { get; private set; }
        public float MaxOxygen { get; private set; }
        public bool IsOxygen
        {
            get { return isOxygen; }
            private set
            {
                if (isOxygen != value)
                {
                    isOxygen = value;

                    if (oxygenCoroutine != null)
                    {
                        Coroutines.StopRoutine(oxygenCoroutine);
                    }

                    oxygenCoroutine = isOxygen 
                        ? StartRestoreOxygenAsynk(_passiveRegenerationPerSec, oxygenChar.StockValue)
                        : StartDamageOxygenAsynk();
                }
            }
        }

        private void OnDisable()
        {
            if(oxygenCoroutine != null)
            {
                Coroutines.StopRoutine(oxygenCoroutine);
            }
            
            PlayerTransition.OnPositionChanged -= (Room room) => IsOxygen = room.presenceOfOxygen;
        }

        private Coroutine StartDamageOxygenAsynk()
        {
            return Coroutines.StartRoutine(DamageOxygenRoutine());
        }

        private IEnumerator DamageOxygenRoutine()
        {
            while (!isOxygen)
            {
                float stockDamage = 1 * Time.deltaTime;
                float damage = stockDamage;

                if (damage > CurrentOxygen)
                {
                    damage -= damage - CurrentOxygen;                    
                }

                CurrentOxygen -= damage;

                OnOxygenDamaged?.Invoke();

                if(CurrentOxygen <= 0)
                {
                    OnOxygenDown?.Invoke(stockDamage * 4);
                }

                yield return null;
            }
        }

        private Coroutine StartRestoreOxygenAsynk(float restoreSpeed, float maxRestore)
        {
            return Coroutines.StartRoutine(RestoreOxygenRoutine(restoreSpeed, maxRestore));
        }
        private IEnumerator RestoreOxygenRoutine(float restoreSpeed, float maxRestore)
        {
            while (CurrentOxygen < maxRestore && isOxygen)
            {
                float stockRestore = restoreSpeed * Time.deltaTime;
                float restore = stockRestore;

                if (CurrentOxygen + restore > maxRestore)
                {
                    restore = maxRestore - CurrentOxygen;
                }

                CurrentOxygen += restore;

                OnOxygenRestore?.Invoke();

                if (CurrentOxygen <= 0)
                {
                    OnOxygenRestored?.Invoke();
                }

                yield return null;
            }
        }
    }
}