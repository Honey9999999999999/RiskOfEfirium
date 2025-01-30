using UnityEngine;

namespace Assets.Scripts.UI.CursorGame.States
{
    public class CursorSimpleState : CursorState
    {
        public CursorSimpleState(CursorFSM stateMachine, Texture2D cursorTexture) : base(stateMachine, cursorTexture)
        {
        }

        public override void SetMode()
        {
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        }

        public override void Update()
        {
            base.Update();

            if (_playerInteractor.MenuMode)
            {
                _stateMachine.EnterIn<CursorMenuState>();
            }

            if (_controller.IsBattle)
            {
                _stateMachine.EnterIn<CursorBattleState>();

                return;
            }
        }
    }
}
