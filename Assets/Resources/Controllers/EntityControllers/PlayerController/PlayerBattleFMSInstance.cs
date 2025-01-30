using Assets.Scripts.Tools;
using FSM;
using UnityEngine;
using WeaponSystem;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class PlayerBattleFMSInstance : FSMExample<FSMPlayer, PlayerState>
    {
        [SerializeField] private Player _player;
        [SerializeField] private Gun _gun;

        public ShellValue<Vector3> targetPosition;

        private void Start()
        {
            targetPosition = new()
            {
                value = new()
            };

            stateMachine.AddState(new SimpleState(stateMachine, _player));
            stateMachine.AddState(new BattleState(stateMachine, _player, targetPosition, _gun));

            stateMachine.EnterIn<SimpleState>();
        }

        public Gun GetGun() => _gun;
    }
}
