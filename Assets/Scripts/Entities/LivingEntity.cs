using EntityControllers;
using System;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [Serializable]
    [RequireComponent(typeof(Rigidbody))]
    public abstract class LivingEntity : MonoBehaviour
    {
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
        }

        protected virtual void OnDeath()
        {

        }
    }
}
