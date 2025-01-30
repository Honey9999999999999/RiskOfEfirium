using System;
using Assets.Resources.BattleSystem;
using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine;
using WeaponSystem;

namespace Assets.Scripts.Controllers.EntityControllers.EnemyController.States
{
    public class AttackState : EnemyBattleState
    {
        public AttackState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, float attackDistance) : base(stateMachine, entity, target, attackDistance)
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

            OnAttack?.Invoke(target.value);
        }
    }
}
