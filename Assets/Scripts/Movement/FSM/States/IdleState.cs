using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using UnityEngine;

namespace MoveFSM
{
    public class IdleState : State
    {
        private EntityController controller;
        MoveFSMInstance instance;
        Rigidbody rigidbody;

        public IdleState(MoveStateMachine stateMachine, LivingEntity entity) : base(stateMachine)
        {
            controller = entity.GetEntityController();
            instance = entity.GetMover();
            rigidbody = instance.gameObject.GetComponent<Rigidbody>();
        }

        public override void Enter()
        {
            base.Enter();

            rigidbody.velocity = Vector3.zero;

            Debug.Log("Enter in Idle State");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (controller.isWalk)
            {
                _stateMachine.EnterIn<WalkState>();

                return;
            }
        }
    }
}
