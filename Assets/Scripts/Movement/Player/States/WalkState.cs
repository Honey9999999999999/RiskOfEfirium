using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;

namespace FSM
{
    internal class WalkState : PlayerMoveState
    {
        private Transform _movebleObject;

        public WalkState(FinalStateMachine<PlayerMoveState> stateMachine, Player entity, ShellValue<float> speed) : base(stateMachine, entity, speed)
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

            if (!_controller.isWalk)
            {
                _stateMachine.EnterIn<IdleState>();

                return;
            }

            ViewOnDirection();

            Vector3 forward = _movebleObject.forward * _controller.moveInput.y;
            Vector3 right = _movebleObject.right * _controller.moveInput.x;
            Vector3 direction = forward + right;

            _rigidbody.velocity = direction * _speed.value;
        }

        protected void ViewOnDirection()
        {
            _entity.transform.LookAt(_movebleObject.position + _controller.viewDirection);
        }
    }
}
