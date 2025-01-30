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
        protected ShellValue<Vector3> targetPosition;
        

        protected EnemyMoveState(FSMMove stateMachine, NavMeshAgent agent, ShellValue<Vector3> targetPos, ImprovedCharacteristic speed) : base(stateMachine, speed)
        {
            this.agent = agent;
            targetPosition = targetPos;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            base.Update();

            DrawTargetPosition();
            DrawViewDirection();
        }

        protected bool IsCurrentPosition()
        {
            Vector3 vector = targetPosition.value - agent.transform.position;
            return (vector.x * vector.x + vector.y * vector.y) < 0.1f;
        }

        protected bool IsLookingAtTarget()
        {
            // Вычисляем направление от агента к объекту
            Vector3 directionToTarget = (targetPosition.value - agent.transform.position).normalized;

            // Игнорируем компонент по оси Y
            directionToTarget.x = 0;
            directionToTarget.z = 0;

            // Вектор взгляда агента
            Vector3 forward = agent.transform.localToWorldMatrix.MultiplyPoint(agent.transform.forward);

            // Считаем угол между forward и directionToTarget
            float angle = Vector3.Angle(forward, directionToTarget);

            // Проверяем, попадает ли угол в допустимый диапазон
            return angle <= 5f;
        }


        private void DrawTargetPosition()
        {
            Drawer.DrawDiamondPoint(targetPosition.value, 2, Color.red, false);
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
