using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class WalkState : EnemyMoveState
    {
        public WalkState(FSMMove stateMachine, Enemy entity, NavMeshAgent agent, ShellValue<float> speed) : base(stateMachine, entity, agent, speed)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _rigidbody.velocity = Vector3.zero;
            _agent.speed = _speed.value;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (!_controller.isWalk)
            {
                _stateMachine.EnterIn<IdleState>();

                return;
            }

            if (NavMeshInteractor.isInitialized)
            {
                _agent.SetDestination(_controller.targetPosition);
            }
        }
    }
}
