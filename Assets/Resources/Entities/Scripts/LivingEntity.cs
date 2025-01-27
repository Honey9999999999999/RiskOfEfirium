using System;
using System.Collections;
using Assets.Resources.ArmorSystem.Scripts;
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

        public EntityHealth health;
        public Armor armor;

        [SerializeField] protected EntityController _entityController;

        public abstract CharacterCharacteristicCard PersonalCCC { get; }

        public Inventory Inventory { get; private set; }


        protected virtual void Awake()
        {
            Inventory = new(PersonalCCC);
            health = new(PersonalCCC);
            armor = new(PersonalCCC);
        }

        private void OnEnable()
        {
            health.OnHealthDown += OnDeath;
        }

        private void OnDisable()
        {
            health.OnHealthDown -= OnDeath;
        }

        public EntityController GetEntityController() => _entityController;

        public Rigidbody GetRigidbody()
        {
            return GetComponent<Rigidbody>();
        }

        public void TakenDamage(TypeDamage type, float damage)
        {
            health.TakenDamage(armor.Reduce(type, damage));

            OnTakenDamage?.Invoke();
        }

        protected virtual void OnDeath()
        {
            OnEntityDeath?.Invoke();
            //OnEntityDeath = null;

            Coroutines.StartRoutine(DestroyEntityRoutine());
        }

        private IEnumerator DestroyEntityRoutine()
        {
            yield return new WaitForSeconds(5);

            Destroy(gameObject);
        }
    }
}
