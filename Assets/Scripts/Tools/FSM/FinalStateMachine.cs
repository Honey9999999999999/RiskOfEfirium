using System;
using System.Collections.Generic;

namespace FSM
{
    public abstract class FinalStateMachine<TState> where TState : IState
    {
        private Dictionary<Type, TState> _states;

        public FinalStateMachine()
        {
            _states = new();
        }

        public TState currentState { get; private set; }

        public void EnterIn<T>() where T : TState
        {
            var type = typeof(T);

            if(type != currentState?.GetType() && _states.TryGetValue(type, out TState state))
            {
                currentState?.Exit();
                currentState = state;
                currentState.Enter();
            }
        }
        public TState GetState<T>() where T : TState
        {
            return (T)_states[typeof(T)];
        }

        public void Update()
        {
            currentState.Update();
        }

        public void AddState(TState state)
        {
            var type = state.GetType();
            if(!_states.TryGetValue(type, out _))
            {
                _states.Add(type, state);
            }            
        }
    }
}
