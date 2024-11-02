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

        public float health => _health;
        public bool isMaxHealth => _health >= _maxHealth;
        public bool isAlive => _health > 0;

        public void TakenDamage(float damage)
        {
            bool beAlive = isAlive;

            if (damage > _health)
            {
                damage -= damage - _health;
            }

            _health -= damage;

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
            if (_timer.isStarted)
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
            while (!isMaxHealth)
            {
                _health += Time.deltaTime * _regenerationPerSec;

                if (_health > _maxHealth)
                {
                    _health = _maxHealth;
                }

                yield return null;
            }
        }
    }
}
