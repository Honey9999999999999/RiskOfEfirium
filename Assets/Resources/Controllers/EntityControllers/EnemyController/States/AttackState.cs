using System;
using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.EnemyController.States
{
    public class AttackState : EnemyBattleState
    {
        public AttackState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, ShellValue<Vector3> lastTargetPos, ShellValue<float> attackDistance) : base(stateMachine, entity, target, lastTargetPos, attackDistance)
        {
        }

        public event Action<Transform> OnAttack;

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

            if (!IsOnAttackLine() || !IsSeeTarget())
            {
                stateMachine.EnterIn<PursuitTargetState>();

                return;
            }

            lastTargetPos.value = target.value.position;

            OnAttack?.Invoke(target.value);
        }
    }
}
