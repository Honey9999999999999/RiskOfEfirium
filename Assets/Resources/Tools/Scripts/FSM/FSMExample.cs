using UnityEngine;

namespace FSM
{
    public abstract class FSMExample<TFSM, TState> : MonoBehaviour where TFSM : FinalStateMachine<TState>, new() where TState : IState
    {
        protected TFSM stateMachine = new();

        protected void FixedUpdate()
        {
            stateMachine.currentState.Update();
        }

        public TState GetState<T>() where T : TState
        {
            return stateMachine.GetState<T>();
        }
    }
}
