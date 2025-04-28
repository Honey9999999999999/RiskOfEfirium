using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InputManager;
using Assets.Scripts.Movement;
using UnityEngine;

namespace PlayerMoveStates
{
    internal class WalkState : PlayerMoveState
    {
        private Transform _movebleObject;

        public WalkState(FSMMove stateMachine, Player entity, ImprovedCharacteristic speed) : base(stateMachine, entity, speed)
        {
            _movebleObject = entity.transform;
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

            if (_controller.IsBattle)
            {
                stateMachine.EnterIn<FlyingState>();

                return;
            }
            if (!_controller.isWalk)
            {
                stateMachine.EnterIn<IdleState>();

                return;
            }

            ViewOnDirection();

            Vector3 forward = _movebleObject.forward * InputHandler.MoveDirection.y;
            Vector3 right = _movebleObject.right * InputHandler.MoveDirection.x;
            Vector3 direction = forward + right;

            _rigidbody.velocity = direction * speed.CurrentValue;
        }

        private void ViewOnDirection()
        {
            _entity.transform.LookAt(_movebleObject.position + _controller.viewDirection);
        }
    }
}
