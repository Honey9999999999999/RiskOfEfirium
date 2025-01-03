using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class WalkState : EnemyMoveState
    {
        public WalkState(FSMMove stateMachine, Enemy entity, NavMeshAgent agent, ImprovedCharacteristic speed) : base(stateMachine, entity, agent, speed)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _rigidbody.velocity = Vector3.zero;
            _agent.speed = _speed.CurrentValue;
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

            if (Game.GetInteractor<NavMeshInteractor>().IsInitialized)
            {
                _agent.SetDestination(_controller.targetPosition);
            }
        }
    }
}
