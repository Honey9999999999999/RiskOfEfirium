using System;
using System.Collections;
using Assets.Scripts.CharacterStatsSystem;
using CoroutineManager;
using MyTimer;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [Serializable]
    public class EntityHealth
    {
        public event Action OnHealthDown;
        public event Action OnHealthRestore;
        public event Action OnHealthRestored;
        public event Action OnHealthDamaged;

        [SerializeField] private float _health;
        [SerializeField] private float _maxHealth;

        private float _regenerationPerSec;
        private float _regenerationCooldown;

        private Timer _timer;
        private Coroutine _regenerationAsync;

        public EntityHealth(CharacterCharacteristicCard ccc)
        {
            ImprovedCharacteristic health = ccc.Get(Characteristics.Health);
            ImprovedCharacteristic regeneration = ccc.Get(Characteristics.Regeneration);

            if (health.StockValue <= 0) throw new Exception($"Heath can't be {health.StockValue}");
            if (regeneration.StockValue <= 0) throw new Exception($"Regeneration can't be {regeneration.StockValue}");

            _maxHealth = health.StockValue;
            _health = _maxHealth;

            _regenerationPerSec = regeneration.StockValue;
            _regenerationCooldown = 5;

            _timer = new();
            _timer.OnStoped += StartRegeneration;

            health.OnCharacteristicChanged += (float value) =>
            {
                float index = _health / _maxHealth;
                _maxHealth = value;
                _health = Mathf.Lerp(0, _maxHealth, index);
            };
            regeneration.OnCharacteristicChanged += (float value) =>
            {
                _regenerationPerSec = value;
            };
        }

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public bool IsMaxHealth => _health >= _maxHealth;
        public bool IsAlive => _health > 0;


        public void TakenDamage(float damage)
        {
            bool beAlive = IsAlive;

            if (damage > _health)
            {
                damage -= damage - _health;
            }

            _health -= damage;

            OnHealthDamaged?.Invoke();

            if (beAlive && _health <= 0)
            {
                OnHealthDown?.Invoke();
                Debug.Log("Death1!");
                _timer.Reset();

                return;
            }

            StartCooldownRegeneration();
        }

        private void StartCooldownRegeneration()
        {
            if (_timer.IsStarted)
            {
                _timer.Reset();
            }

            _timer.Start(_regenerationCooldown);
            StopRegeneration();
        }

        private void StartRegeneration()
        {
            _regenerationAsync = Coroutines.StartRoutine(RegenerationRoutine());
        }

        private void StopRegeneration()
        {
            if (_regenerationAsync != null)
            {
                Coroutines.StopRoutine(_regenerationAsync);
            }
        }

        private IEnumerator RegenerationRoutine()
        {
            while (!IsMaxHealth)
            {
                _health = Mathf.Clamp(_health + Time.deltaTime * _regenerationPerSec, 0, _maxHealth);

                OnHealthRestore?.Invoke();

                if (IsMaxHealth)
                    OnHealthRestored?.Invoke();

                yield return null;
            }
        }
    }
}
