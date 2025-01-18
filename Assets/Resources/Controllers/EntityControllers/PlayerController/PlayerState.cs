using Architecture;
using FSM;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public abstract class PlayerState : IState
    {
        protected FSMPlayer _stateMachine;
        protected Player _player;
        protected PlayerController _controller;
        protected PlayerInteractor _playerInteractor;

        public PlayerState(FSMPlayer fSMPlayer, Player player)
        {
            _stateMachine = fSMPlayer;
            _player = player;
            _controller = player.GetPlayerController();

            _playerInteractor = Game.GetInteractor<PlayerInteractor>();
            _playerInteractor.OnMenuOpened += () => _stateMachine.EnterIn<SimpleState>();
        }
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}
