using CoroutineManager;
using EntityControllers;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class LivingEntity : MonoBehaviour
    {
        public event Action OnTakenDamage;
        public event Action OnEntityDeath;

        [SerializeField] protected EntityHealth _health = new();
        [SerializeField] protected EntityController _entityController;

        public LivingEntity()
        {
            _health.OnHealthDown += OnDeath;
        }

        public EntityController GetEntityController() => _entityController;

        public Rigidbody GetRigidbody()
        {
            return GetComponent<Rigidbody>();
        }

        public void TakenDamage(float damage)
        {
            _health.TakenDamage(damage);

            OnTakenDamage?.Invoke();
        }

        protected virtual void OnDeath()
        {
            OnEntityDeath?.Invoke();

            Coroutines.StartRoutine(DestroyEntityRoutine());
        }

        private IEnumerator DestroyEntityRoutine()
        {
            yield return new WaitForSeconds(5);

            Destroy(gameObject);
        }
    }
}
