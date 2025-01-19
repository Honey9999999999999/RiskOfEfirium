using System;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InputManager;
using Assets.Scripts.Movement;
using UnityEngine;

namespace PlayerMoveStates
{
    public class FlyingState : PlayerMoveState
    {
        public static event Action OnPlayerRotated;

        private Transform _playerModel;

        public FlyingState(FSMMove stateMachine, Player entity, Transform playerModel, ImprovedCharacteristic speed) : base(stateMachine, entity, speed)
        {
            _playerModel = playerModel;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();

            _playerModel.localEulerAngles = Vector3.zero;
        }

        public override void Update()
        {
            base.Update();

            if (!_controller.isBattle)
            {
                _stateMachine.EnterIn<IdleState>();

                return;
            }

            ViewOnDirection();

            Transform camera = Camera.current.transform;

            Vector3 forward = new Vector3(camera.forward.x, 0, camera.forward.z) * InputHandler.instance.moveVector.y;
            Vector3 right = new Vector3(camera.right.x, 0, camera.right.z) * InputHandler.instance.moveVector.x;
            Vector3 direction = forward + right;

            _rigidbody.velocity = direction * (_speed.CurrentValue * 0.75f);
        }

        private void ViewOnDirection()
        {
            Vector3 target = _entity.GetBattleFSM().targetPosition.value;
            target = new Vector3(target.x, 1, target.z);

            _playerModel.LookAt(target, Vector3.up);

            OnPlayerRotated?.Invoke();
        }
    }
}
