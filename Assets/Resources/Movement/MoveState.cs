using Assets.Scripts.CharacterStatsSystem;
using FSM;

namespace Assets.Scripts.Movement
{
    public abstract class MoveState : IState
    {
        protected FSMMove stateMachine;
        protected ImprovedCharacteristic speed;

        public MoveState(FSMMove stateMachine, ImprovedCharacteristic speed) : base()
        {
            this.stateMachine = stateMachine;
            this.speed = speed;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}
