using Architecture;
using Assets.Scripts.Controllers.EntityControllers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.UI.CursorGame
{
    public abstract class CursorState : IState
    {
        protected CursorFSM _stateMachine;
        protected PlayerController _controller;
        protected Texture2D _cursorTexture;

        public CursorState(CursorFSM stateMachine, Texture2D cursorTexture)
        {
            _stateMachine = stateMachine;
            _controller = Game.GetInteractor<PlayerInteractor>().player.GetPlayerController();
            _cursorTexture = cursorTexture;
        }

        public virtual void Enter() { SetMode(); }
        public virtual void Exit() { }
        public virtual void Update() { }

        public abstract void SetMode();
    }
}
