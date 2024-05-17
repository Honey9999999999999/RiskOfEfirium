using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using UnityEngine;

namespace FSM
{
    public class IdleState : MoveState
    {
        private EntityController controller;
        MovePlayerFSMInstance instance;
        Rigidbody rigidbody;

        public IdleState(FinalStateMachine<MoveState> stateMachine, LivingEntity entity) : base(stateMachine)
        {
            controller = entity.GetEntityController<PlayerController>();
            instance = entity.GetMover();
            rigidbody = instance.gameObject.GetComponent<Rigidbody>();
        }

        public override void Enter()
        {
            base.Enter();

            rigidbody.velocity = Vector3.zero;
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
