using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using System;
using UnityEngine;

namespace MoveFSM
{
    internal class WalkState : State
    {
        public event Action OnWalk;

        LivingEntity entity;
        private EntityController controller;
        Transform movebleObject;
        MoveFSMInstance instance;
        Rigidbody rigidbody;

        public WalkState(MoveStateMachine stateMachine, LivingEntity entity) : base(stateMachine)
        {
            this.entity = entity;
            controller = entity.GetEntityController();
            movebleObject = entity.gameObject.transform;
            instance = entity.GetMover();
            rigidbody = instance.gameObject.GetComponent<Rigidbody>();
        }

        public override void Enter()
        {
            base.Enter();
            
            Debug.Log("Enter in Walk State");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (!controller.isWalk)
            {
                _stateMachine.EnterIn<IdleState>();

                return;
            }

            OnWalk?.Invoke();

            Vector3 forward = movebleObject.forward * controller.moveInput.y;
            Vector3 right = movebleObject.right * controller.moveInput.x;
            Vector3 direction = forward + right;

            rigidbody.velocity = direction * instance.GetWalkSpeed();
        }
    }
}
