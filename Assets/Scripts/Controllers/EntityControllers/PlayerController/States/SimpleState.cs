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
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (!_playerInteractor.MenuMode && _controller.isBattle)
            {
                _stateMachine.EnterIn<BattleState>();

                return;
            }
        }
    }
}
