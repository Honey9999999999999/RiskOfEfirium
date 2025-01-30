using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using UnityEngine;

namespace PlayerMoveStates
{
    public class IdleState : PlayerMoveState
    {
        public IdleState(FSMMove stateMachine, Player entity, ImprovedCharacteristic speed) : base(stateMachine, entity, speed)
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

            if (!_playerInteractor.MenuMode && _controller.IsBattle)
            {
                stateMachine.EnterIn<FlyingState>();

                return;
            }
            if (!_playerInteractor.MenuMode && _controller.isWalk)
            {
                stateMachine.EnterIn<WalkState>();

                return;
            }
        }
    }
}
