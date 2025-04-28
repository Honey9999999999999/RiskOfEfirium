using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class RotateState : EnemyMoveState
    {
        public RotateState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> followPos, ShellValue<Vector3> trackingPos, ImprovedCharacteristic speed) : base(stateMachine, agent, followPos, trackingPos, speed)
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

            if (IsLookingAtTarget())
            {
                stateMachine.EnterIn<IdleState>();
                return;
            }

            Vector3 dirAngle = (trackingPosition.value - agent.transform.position).normalized;
            dirAngle.y = 0;

            Quaternion lookRotation = Quaternion.LookRotation(dirAngle);
            agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
    }
}