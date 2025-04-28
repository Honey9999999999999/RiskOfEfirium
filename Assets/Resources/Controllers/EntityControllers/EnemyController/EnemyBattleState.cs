using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.EnemyController
{
    public class EnemyBattleState : EnemyState
    {
        protected ShellValue<Vector3> lastTargetPos;
        private readonly ShellValue<float> attackDistance;
        public EnemyBattleState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, ShellValue<Vector3> lastTargetPos, ShellValue<float> attackDistance) : base(stateMachine, entity, target)
        {
            this.lastTargetPos = lastTargetPos;
            this.attackDistance = attackDistance;
        }

        protected bool IsOnAttackLine()
        {
            if (target.value == null)
            {
                return false;
            }

            Vector3 vector = target.value.position - entity.transform.position;
            float distance = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);

            return distance < attackDistance.value;
        }
    }
}
