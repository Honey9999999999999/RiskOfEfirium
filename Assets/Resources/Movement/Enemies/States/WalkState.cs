using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class WalkState : EnemyMoveState
    {
        public WalkState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> targetPos, ImprovedCharacteristic speed) : base(stateMachine, agent, targetPos, speed)
        {
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (IsCurrentPosition())
            {
                stateMachine.EnterIn<IdleState>();

                return;
            }

            if (Game.GetInteractor<NavMeshInteractor>().IsInitialized)
            {
                agent.SetDestination(targetPosition.value);
            }
        }
    }
}
