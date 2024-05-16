using System;
using System.Collections.Generic;

namespace MoveFSM
{
    public class MoveStateMachine
    {
        private Dictionary<Type, State> _states;

        public MoveStateMachine()
        {
            _states = new();
        }

        public State currentState { get; private set; }

        public void EnterIn<TState>() where TState : State
        {
            var type = typeof(TState);

            if(type != currentState?.GetType() && _states.TryGetValue(type, out State state))
            {
                currentState?.Exit();
                currentState = state;
                currentState.Enter();
            }
        }
        public TState GetState<TState>() where TState : State
        {
            return (TState)_states[typeof(TState)];
        }

        public void Update()
        {
            currentState.Update();
        }

        public void AddState(State state)
        {
            var type = state.GetType();
            if(!_states.TryGetValue(type, out _))
            {
                _states.Add(type, state);
            }            
        }
    }
}
