using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using FSM;
using UnityEditorInternal;
using UnityEngine.AI;

namespace Assets.Scripts.Movement
{
    public abstract class EnemyMoveState : IState
    {
        protected FinalStateMachine<EnemyMoveState> _stateMachine;
        protected Enemy _entity;
        protected EnemyController _controller;
        protected NavMeshAgent _agent;

        public EnemyMoveState(FinalStateMachine<EnemyMoveState> stateMachine, Enemy entity, NavMeshAgent agent) : base()
        {
            _stateMachine = stateMachine;
            _entity = entity;
            _controller = entity.GetEntityController<EnemyController>();
            _agent = agent;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}
