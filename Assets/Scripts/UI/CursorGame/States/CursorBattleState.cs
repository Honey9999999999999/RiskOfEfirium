using UnityEngine;

namespace Assets.Scripts.UI.CursorGame.States
{
    public class CursorBattleState : CursorState
    {
        public CursorBattleState(CursorFSM stateMachine, Texture2D cursorTexture) : base(stateMachine, cursorTexture)
        {
        }

        public override void SetMode()
        {
            Cursor.SetCursor(_cursorTexture, new Vector2(_cursorTexture.width / 2, _cursorTexture.height / 2), CursorMode.ForceSoftware);
        }

        public override void Update()
        {
            base.Update();

            if (!_controller.isBattle)
            {
                _stateMachine.EnterIn<CursorSimpleState>();

                return;
            }
        }
    }
}
