using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.EnemyController
{
    public class EnemyBattleState : EnemyState
    {
        private float _attackDistance;
        public EnemyBattleState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, float attackDistance) : base(stateMachine, entity, target)
        {
            _attackDistance = attackDistance;
        }

        protected bool IsReadyAttack()
        {
            Vector3 vector = _target.value.position - _entity.transform.position;

            float distance = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);

            return distance < _attackDistance;
        }
    }
}
