using Assets.Scripts.Tools;
using EntityControllers;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Movement
{
    public abstract class EnemyMoveState : MoveState
    {
        protected Enemy _entity;
        protected EnemyController _controller;
        protected Rigidbody _rigidbody;
        protected NavMeshAgent _agent;

        protected EnemyMoveState(FSMMove stateMachine, Enemy entity, NavMeshAgent agent, ShellValue<float> speed) : base(stateMachine, speed)
        {
            _entity = entity;
            _controller = (EnemyController)_entity.GetEntityController();
            _rigidbody = _entity.GetRigidbody();
            _agent = agent;
        }
    }
}
