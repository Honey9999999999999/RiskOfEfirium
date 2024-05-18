using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;
using Assets.Scripts.Entities;
using EntityControllers;

namespace Assets.Scripts.Movement
{
    public abstract class MoveState<TMoveState, TEntity, TController> : IState 
        where TMoveState : IState 
        where TEntity : LivingEntity 
        where TController : EntityController
    {
        protected FinalStateMachine<TMoveState> _stateMachine;
        protected TEntity _entity;
        protected TController _controller;
        protected ShellValue<float> _speed;
        protected Rigidbody _rigidbody;

        public MoveState(FinalStateMachine<TMoveState> stateMachine, TEntity entity, ShellValue<float> speed) : base()
        {
            _stateMachine = stateMachine;
            _entity = entity;
            _controller = (TController)entity.GetEntityController();
            _speed = speed;
            _rigidbody = _entity.GetRigidbody();
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }
    }
}
