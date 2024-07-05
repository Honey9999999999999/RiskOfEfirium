using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.EnemyController.States
{
    public class AttackState : EnemyBattleState
    {
        private Gun _gun;

        public AttackState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, float attackDistance, Gun gun) : base(stateMachine, entity, target, attackDistance)
        {
            _gun = gun;
        }

        public override void Enter()
        {
            base.Enter();
            _targetPosition = _entity.transform.position + (_target.value.position - _entity.transform.position).normalized * 0.5f;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (!IsReadyAttack())
            {
                _stateMachine.EnterIn<PursuitTargetState>();

                return;
            }

            _gun.Fire(_target.value.GetComponent<Collider>().bounds.center);
        }
    }
}
