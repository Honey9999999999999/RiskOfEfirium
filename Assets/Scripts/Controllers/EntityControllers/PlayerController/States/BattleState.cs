using Architecture;
using Assets.Scripts.Tools;
using UI.Cursor;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class BattleState : PlayerState
    {
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

            Game.GetInteractor<CursorInteractor>().cursor.SetMode(UI.Cursor.CursorMode.Battle);
            _controller.OnAttackInput += Fire;
        }

        public override void Exit()
        {
            base.Exit();

            _controller.OnAttackInput -= Fire;
        }

        public override void Update()
        {
            base.Update();

            if (!_controller.isBattle)
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
                    _targetPosition.value = hit.point + new Vector3(0, 1, 0);
                }
            }
        }

        private void Fire()
        {
            _gun.Fire(_targetPosition.value);
        }
    }
}
