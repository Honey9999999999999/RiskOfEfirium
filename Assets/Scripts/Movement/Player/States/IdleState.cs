using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;

namespace FSM
{
    public class IdleState : PlayerMoveState
    {
        public IdleState(FSMMove stateMachine, Player entity, ShellValue<float> speed) : base(stateMachine, entity, speed)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _rigidbody.velocity = Vector3.zero;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (_controller.isWalk)
            {
                _stateMachine.EnterIn<WalkState>();

                return;
            }
        }
    }
}
