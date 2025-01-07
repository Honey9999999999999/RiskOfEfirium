using UnityEngine;

namespace Assets.Scripts.UI.CursorGame.States
{
    internal class CursorMenuState : CursorState
    {
        public CursorMenuState(CursorFSM stateMachine, Texture2D cursorTexture) : base(stateMachine, cursorTexture)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void SetMode()
        {
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }

        public override void Update()
        {
            base.Update();

            if (!_playerInteractor.MenuMode)
            {
                _stateMachine.EnterIn<CursorSimpleState>();
            }
        }
    }
}
