using UnityEngine;

namespace FSM
{
    public abstract class FSMExample<TState> : MonoBehaviour where TState : IState
    {
        protected FinalStateMachine<TState> _stateMachine = new();

        protected void Update()
        {
            _stateMachine.currentState.Update();
        }

        public TState GetState<T>() where T : TState
        {
            return _stateMachine.GetState<T>();
        }
    }
}
