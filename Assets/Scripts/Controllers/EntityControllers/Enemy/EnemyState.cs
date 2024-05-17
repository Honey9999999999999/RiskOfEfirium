using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy
{
    public class EnemyState : IState
    {        
        protected FinalStateMachine<EnemyState> _stateMachine;
        protected Collider _target;
        protected Vector3 _targetPosition;

        public EnemyState(FinalStateMachine<EnemyState> stateMachine, Collider target) : base()
        {
            _stateMachine = stateMachine;
            _target = target;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        public Vector3 GetDirectionToTarget()
        {
            return _targetPosition;
        }
    }
}
