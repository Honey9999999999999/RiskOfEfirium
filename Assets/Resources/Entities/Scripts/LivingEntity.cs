using System;
using System.Collections;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;
using CoroutineManager;
using EntityControllers;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class LivingEntity : MonoBehaviour
    {
        public event Action OnTakenDamage;
        public event Action OnEntityDeath;

        public EntityHealth health = new();

        [SerializeField] protected EntityController _entityController;

        public abstract CharacterCharacteristicCard PersonalCCC { get; }

        public Inventory Inventory { get; }

        public LivingEntity()
        {
            Inventory = new(PersonalCCC);
            health.OnHealthDown += OnDeath;
        }

        public EntityController GetEntityController() => _entityController;

        public Rigidbody GetRigidbody()
        {
            return GetComponent<Rigidbody>();
        }

        public void TakenDamage(float damage)
        {
            health.TakenDamage(damage);

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
