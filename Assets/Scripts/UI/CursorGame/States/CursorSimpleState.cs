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
            Cursor.SetCursor(_cursorTexture, new Vector2(0, 0), CursorMode.ForceSoftware);
        }

        public override void Update()
        {
            base.Update();

            if (_controller.isBattle)
            {
                _stateMachine.EnterIn<CursorBattleState>();

                return;
            }
        }
    }
}
