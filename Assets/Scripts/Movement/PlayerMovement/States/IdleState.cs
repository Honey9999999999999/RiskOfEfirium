using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;

namespace PlayerMoveStates
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

            if (_controller.isBattle)
            {
                _stateMachine.EnterIn<FlyingState>();

                return;
            }
            if (_controller.isWalk)
            {
                _stateMachine.EnterIn<WalkState>();

                return;
            }
        }
    }
}
