using CoroutineManager;
using MyTimer;
using System;
using System.Collections;
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

        [SerializeField, Min(0)] private float _health;
        [SerializeField, Min(0)] private float _maxHealth;

        [SerializeField, Min(0)] private float _regenerationPerSec;
        [SerializeField, Min(0)] private float _regenerationCooldown;

        private Timer _timer;
        private Coroutine _regenerationAsync;

        public EntityHealth() : this(100, 5, 5) { }
        public EntityHealth(float maxHealth, float regenerationPerSec, float regenerationCooldown)
        {
            if (maxHealth <= 0)
            {
                maxHealth = 100;
            }

            _maxHealth = maxHealth;
            _health = _maxHealth;

            _regenerationPerSec = regenerationPerSec;
            _regenerationCooldown = regenerationCooldown;

            _timer = new();
            _timer.OnStoped += StartRegeneration;
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

                if(IsMaxHealth)
                    OnHealthRestored?.Invoke();

                yield return null;
            }
        }
    }
}
