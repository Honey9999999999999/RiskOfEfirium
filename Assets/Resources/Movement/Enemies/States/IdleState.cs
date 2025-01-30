using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class IdleState : EnemyMoveState
    {
        public IdleState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> targetPos, ImprovedCharacteristic speed) : base(stateMachine, agent, targetPos, speed)
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

            //if(_controller.TryGetTarget(out _) && !IsLookingAtTarget())
            //{
            //    stateMachine.EnterIn<RotateState>();
            //    return;
            //}
        }
    }
}
