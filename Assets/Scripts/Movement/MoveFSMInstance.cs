using Assets.Scripts.Entities;
using FSM;
using System;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class MoveFSMInstance : FSMExample<MoveState>
    {
        public event Action OnInitialized;

        [SerializeField] private LivingEntity entity;

        [SerializeField] private float _walkSpeed;
        
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

        public float GetWalkSpeed() => _walkSpeed;
    }
}
