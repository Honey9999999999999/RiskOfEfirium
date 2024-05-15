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

            if(type != currentState.GetType() && _states.TryGetValue(type, out State state))
            {
                currentState?.Exit();
                currentState = state;
                currentState.Enter();
            }
        }

        public void Update()
        {
            currentState.Update();
        }

        public void AddState<TState>() where TState : State, new()
        {
            if(!_states.TryGetValue(typeof(TState), out _))
            {
                _states.Add(typeof(TState), new TState());
            }            
        }
    }
}
