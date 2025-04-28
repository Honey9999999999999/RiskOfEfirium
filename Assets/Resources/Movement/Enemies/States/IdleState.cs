using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class IdleState : EnemyMoveState
    {
        public IdleState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> followPos, ShellValue<Vector3> trackingPos, ImprovedCharacteristic speed) : base(stateMachine, agent, followPos, trackingPos, speed)
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

            if (!IsCurrentPosition())
            {
                stateMachine.EnterIn<WalkState>();
                return;
            }

            if (!IsLookingAtTarget())
            {
                stateMachine.EnterIn<RotateState>();
                return;
            }
        }
    }
}
