using Assets.Scripts.Controllers.EntityControllers.EnemyController;
using Assets.Scripts.Controllers.EntityControllers.EnemyController.States;
using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class PursuitTargetState : EnemyBattleState
    {
        public PursuitTargetState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, float attackDistance) : base(stateMachine, entity, target, attackDistance)
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

            if (_target.value == null)
            {
                _stateMachine.EnterIn<SearchingTargetState>();

                return;
            }
            else
            {
                _targetPosition = _target.value.position;
            }

            if (IsReadyAttack())
            {                
                _stateMachine.EnterIn<AttackState>();

                return;
            }
        }
    }
}
