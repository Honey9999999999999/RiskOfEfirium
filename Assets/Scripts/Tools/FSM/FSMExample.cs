using UnityEngine;

namespace FSM
{
    public abstract class FSMExample<TFSM, TState> : MonoBehaviour where TFSM : FinalStateMachine<TState>, new() where TState : IState
    {
        protected TFSM _stateMachine = new();

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
