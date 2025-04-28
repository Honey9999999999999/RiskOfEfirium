using System.Collections.Generic;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Movement
{
    public abstract class EnemyMoveState : MoveState
    {
        protected NavMeshAgent agent;
        protected ShellValue<Vector3> followPosition;
        protected ShellValue<Vector3> trackingPosition;


        protected EnemyMoveState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> followPos, ShellValue<Vector3> trackingPos, ImprovedCharacteristic speed) : base(stateMachine, speed)
        {
            this.agent = agent;
            followPosition = followPos;
            trackingPosition = trackingPos;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            IsLookingAtTarget();
        }

        protected bool IsCurrentPosition()
        {
            Vector3 vector = followPosition.value - agent.transform.position;
            return (vector.x * vector.x + vector.y * vector.y) < 0.1f;
        }

        protected bool IsLookingAtTarget()
        {
            if(trackingPosition.value == Vector3.zero)
            {
                return true;
            }

            Vector3 directionToTarget = (trackingPosition.value - agent.transform.position).normalized;
            directionToTarget.y = 0;

            Vector3 forward = agent.transform.forward;
            forward.y = 0;

            float angle = Vector3.Angle(forward, directionToTarget);

            trackingPosition.value = angle <= 5f ? Vector3.zero : trackingPosition.value;

            return angle <= 5f;
        }


        private void DrawTargetPosition()
        {
            Drawer.DrawDiamondPoint(followPosition.value, 2, Color.red, false);
        }
        private void DrawViewDirection()
        {
            List<Vector3> points = new()
            {
                agent.transform.position,
                agent.transform.position + agent.transform.forward * 10
            };

            Drawer.DrawCurve(points, Vector3.zero, Color.blue);
        }
    }
}
