using System;
using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using MyTimer;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Zones
{
    [Serializable]
    [RequireComponent(typeof(Collider))]
    public abstract class Zone : MonoBehaviour
    {
        [SerializeField, Min(0)] private float radius;

        [SerializeField, Min(0)] private float timeBetweenTick;
        [SerializeField, Min(0)] private float alifeTime;

        protected List<LivingEntity> entities;

        private Timer alifeTimer;
        private Timer durationTimer;

        public Side Side { get { return side; } set { side = side == Side.NoOne ? value : side; } }
        private Side side;

        public CharacterCharacteristicCard CCC { get { return ccc; } set { ccc ??= value; } }
        private CharacterCharacteristicCard ccc;

        private void Awake()
        {
            transform.localScale = Vector3.one * radius;

            entities = new List<LivingEntity>();

            alifeTimer = new();
            durationTimer = new();

            alifeTimer.OnStoped += DestroyZone;
            durationTimer.OnStoped += () => { Do(); durationTimer.Start(timeBetweenTick); };

            alifeTimer.Start(alifeTime);
            durationTimer.Start(timeBetweenTick);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && other.TryGetComponent(out LivingEntity entity))
            {
                entities.Add(entity);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (!other.isTrigger && other.TryGetComponent(out LivingEntity entity))
            {
                entities.Remove(entity);
            }
        }

        protected abstract void Do();

        private void DestroyZone()
        {
            durationTimer.Reset();
            Destroy(gameObject);
        }
    }
}