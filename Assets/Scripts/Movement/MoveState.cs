using Assets.Scripts.Tools;
using FSM;

namespace Assets.Scripts.Movement
{
    public abstract class MoveState : IState
    {
        protected FSMMove _stateMachine;
        protected ShellValue<float> _speed;

        public MoveState(FSMMove stateMachine, ShellValue<float> speed) : base()
        {
            _stateMachine = stateMachine;
            _speed = speed;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}
