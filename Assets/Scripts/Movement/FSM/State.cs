namespace MoveFSM
{
    public abstract class State
    {
        private MoveStateMachine _stateMachine;

        public State(MoveStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }
}

