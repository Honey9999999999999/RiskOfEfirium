using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using UnityEngine;

namespace FSM
{
    internal class WalkState : MoveState
    {
        LivingEntity entity;
        private EntityController controller;
        Transform movebleObject;
        MovePlayerFSMInstance instance;
        Rigidbody rigidbody;

        public WalkState(FinalStateMachine<MoveState> stateMachine, LivingEntity entity) : base(stateMachine)
        {
            this.entity = entity;
            controller = entity.GetEntityController<PlayerController>();
            movebleObject = entity.gameObject.transform;
            instance = entity.GetMover();
            rigidbody = instance.gameObject.GetComponent<Rigidbody>();
        }

        public override void Enter()
        {
            base.Enter();
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

            ViewOnDirection();

            Vector3 forward = movebleObject.forward * controller.moveInput.y;
            Vector3 right = movebleObject.right * controller.moveInput.x;
            Vector3 direction = forward + right;

            rigidbody.velocity = direction * instance.GetWalkSpeed();
        }

        protected void ViewOnDirection()
        {
            entity.transform.LookAt(movebleObject.position + controller.viewDirection);
        }
    }
}
