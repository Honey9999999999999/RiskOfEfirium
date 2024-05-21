using Assets.Scripts.Tools;
using FSM;
using TMPro;
using UnityEngine;

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

            _stateMachine.AddState(new SimpleState(_stateMachine, _player));
            _stateMachine.AddState(new BattleState(_stateMachine, _player, targetPosition, _gun));

            _stateMachine.EnterIn<SimpleState>();
        }
    }
}
