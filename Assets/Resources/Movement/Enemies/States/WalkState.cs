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
        public WalkState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> followPos, ShellValue<Vector3> trackingPos, ImprovedCharacteristic speed) : base(stateMachine, agent, followPos, trackingPos, speed)
        {
        }

        public override void Enter()
        {
            base.Enter();

            agent.speed = speed.CurrentValue;
        }

        public override void Exit()
        {
            base.Exit();

            agent.velocity = Vector3.zero;
            agent.ResetPath();
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
                agent.SetDestination(followPosition.value);
            }
        }
    }
}
