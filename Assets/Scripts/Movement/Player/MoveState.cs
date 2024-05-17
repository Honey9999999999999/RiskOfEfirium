using FSM;

namespace Assets.Scripts.Movement
{
    public class MoveState : IState
    {
        protected FinalStateMachine<MoveState> _stateMachine;

        public MoveState(FinalStateMachine<MoveState> stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}
