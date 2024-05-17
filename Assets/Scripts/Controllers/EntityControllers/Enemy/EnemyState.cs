using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy
{
    public class EnemyState : IState
    {        
        protected FinalStateMachine<EnemyState> _stateMachine;

        protected LivingEntity _entity;

        protected ShellValue<Transform> _target;
        protected Vector3 _targetPosition;

        public EnemyState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target) : base()
        {
            _stateMachine = stateMachine;
            _entity = entity;
            _target = target;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        public Vector3 GetTargetPosition()
        {
            return _targetPosition;
        }
    }
}
