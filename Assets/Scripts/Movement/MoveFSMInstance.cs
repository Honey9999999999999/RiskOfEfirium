using Assets.Scripts.Entities;
using MoveFSM;
using System;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class MoveFSMInstance : MonoBehaviour
    {
        public event Action OnInitialized;

        [SerializeField] private LivingEntity entity;

        [SerializeField] private float _walkSpeed;

        private MoveStateMachine _stateMachine = new();
        
        private void Awake()
        {
            if(entity == null)
            {
                entity = gameObject.GetComponent<LivingEntity>();
            }
        }
        private void Start()
        {
            _stateMachine.AddState(new IdleState(_stateMachine, entity));
            _stateMachine.AddState(new WalkState(_stateMachine, entity));

            _stateMachine.EnterIn<IdleState>();

            OnInitialized?.Invoke();
        }

        private void Update()
        {
            _stateMachine.currentState.Update();
        }

        public TState GetState<TState>() where TState : State
        {
            return _stateMachine.GetState<TState>();
        }

        public float GetWalkSpeed() => _walkSpeed;
    }
}
