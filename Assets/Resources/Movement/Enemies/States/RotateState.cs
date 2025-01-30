using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using EnemyMoveStates;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class RotateState : EnemyMoveState
    {
        public RotateState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> targetPos, ImprovedCharacteristic speed) : base(stateMachine, agent, targetPos, speed)
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

            //if (!_controller.TryGetTarget(out _) || IsLookingAtTarget())
            //{
            //    stateMachine.EnterIn<IdleState>();
            //    return;
            //}

            //Debug.Log("Rotate");

            //Vector3 dirAngle = (_controller.TargetPosition - agent.transform.position).normalized;
            ////dirAngle.x *= 0;
            ////dirAngle.z *= 0;
            //Quaternion lookRotation = Quaternion.LookRotation(dirAngle);
            //agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * agent.angularSpeed);
        }
    }
}