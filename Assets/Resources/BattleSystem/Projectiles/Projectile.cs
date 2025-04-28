using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using MyTimer;
using UnityEngine;

namespace Assets.Resources.BattleSystem
{
    [RequireComponent(typeof(Collider), typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private bool isPostActivate;
        [SerializeField, Min(0)] private float activateTime;

        public Coroutine FlightCoroutine { get { return flightCoroutine; } set { flightCoroutine ??= value; } }
        private Coroutine flightCoroutine;

        public Side Side { get { return side; } set { side = side == Side.NoOne ? value : side; } }
        private Side side;

        public LivingEntity Invoker
        {
            get { return invoker; }
            set
            {
                if (invoker == null)
                {
                    invoker = value;
                    ccc = invoker.PersonalCCC.Clone();
                }
            }
        }
        private LivingEntity invoker;

        protected CharacterCharacteristicCard ccc;


        private void Awake()
        {
            if (isPostActivate)
            {
                Timer timer = new();
                timer.OnStoped += () => Implement(null);
                timer.Start(activateTime);
            }
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && (other.gameObject != invoker.gameObject || invoker == null))    
            {
                Implement(other);
            }
        }

        protected abstract void Do(Collider other);

        private void Implement(Collider other)
        {
            Do(other);

            StopCoroutine(FlightCoroutine);
            Destroy(gameObject);
        }
    }
}