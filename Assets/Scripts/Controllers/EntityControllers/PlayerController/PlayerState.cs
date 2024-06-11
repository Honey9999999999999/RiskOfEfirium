using FSM;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public abstract class PlayerState : IState
    {
        protected FSMPlayer _stateMachine;
        protected Player _player;
        protected PlayerController _controller;

        public PlayerState(FSMPlayer fSMPlayer, Player player)
        {
            _stateMachine = fSMPlayer;
            _player = player;
            _controller = player.GetPlayerController();
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
