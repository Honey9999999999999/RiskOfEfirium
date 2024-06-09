using Assets.Scripts.InputManager;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;

namespace PlayerMoveStates
{
    internal class WalkState : PlayerMoveState
    {
        private Transform _movebleObject;

        public WalkState(FSMMove stateMachine, Player entity, ShellValue<float> speed) : base(stateMachine, entity, speed)
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

            if (_controller.isBattle)
            {
                _stateMachine.EnterIn<FlyingState>();

                return;
            }
            if (!_controller.isWalk)
            {
                _stateMachine.EnterIn<IdleState>();

                return;
            }

            ViewOnDirection();

            Vector3 forward = _movebleObject.forward * InputHandler.instance.moveVector.y;
            Vector3 right = _movebleObject.right * InputHandler.instance.moveVector.x;
            Vector3 direction = forward + right;

            _rigidbody.velocity = direction * _speed.value;
        }

        private void ViewOnDirection()
        {
            _entity.transform.LookAt(_movebleObject.position + _controller.viewDirection);
        }
    }
}
