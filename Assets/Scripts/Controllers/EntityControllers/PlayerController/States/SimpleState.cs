using Architecture;
using UI.Cursor;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class SimpleState : PlayerState
    {
        public SimpleState(FSMPlayer fSMPlayer, Player player) : base(fSMPlayer, player)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Game.GetInteractor<CursorInteractor>().cursor.SetMode(UI.Cursor.CursorMode.Standart);
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
                _stateMachine.EnterIn<BattleState>();

                return;
            }
        }
    }
}
