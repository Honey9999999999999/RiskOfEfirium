using System;
using Assets.Scripts.InputManager;
using Assets.Scripts.Tools;
using UnityEngine;
using WeaponSystem;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class BattleState : PlayerState
    {
        public static event Action OnBattleModeEnter;
        public static event Action OnBattleModeExit;

        private ShellValue<Vector3> _targetPosition;
        private Gun _gun;

        public BattleState(FSMPlayer fSMPlayer, Player player, ShellValue<Vector3> targetPosition, Gun gun) : base(fSMPlayer, player)
        {
            _targetPosition = targetPosition;
            _gun = gun;
        }

        public override void Enter()
        {
            base.Enter();

            InputHandler.OnAttackInput += Fire;
            OnBattleModeEnter?.Invoke();
        }

        public override void Exit()
        {
            base.Exit();

            InputHandler.OnAttackInput -= Fire;
            OnBattleModeExit?.Invoke();
        }

        public override void Update()
        {
            base.Update();

            if (!_controller.IsBattle)
            {
                _stateMachine.EnterIn<SimpleState>();

                return;
            }

            GetTargetPosition();
        }

        private void GetTargetPosition()
        {
            if (CursorHitHandler.RaycastNoTriggers(out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent<Enemy>(out _))
                {
                    _targetPosition.value = hit.point - new Vector3(0, -0.5f, 0);
                }
                else
                {
                    _targetPosition.value = new Vector3(hit.point.x, _gun.transform.position.y, hit.point.z);
                }
            }
        }

        private void Fire()
        {
            _gun.Fire(_targetPosition.value);
        }
    }
}
