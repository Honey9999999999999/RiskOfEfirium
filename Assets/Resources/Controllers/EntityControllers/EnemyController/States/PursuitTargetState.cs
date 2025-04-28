using System;
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
        public event Action<Vector3> OnPursuit;

        public PursuitTargetState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, ShellValue<Vector3> lastTargetPos, ShellValue<float> attackDistance) : base(stateMachine, entity, target, lastTargetPos, attackDistance)
        {
        }

        public override void Enter()
        {
            base.Enter();

            OnPursuit.Invoke(lastTargetPos.value + new Vector3(0, 2, 0));
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (!IsSeeTarget())
            {
                if (Vector3.Distance(lastTargetPos.value, entity.transform.position) < 0.1f)
                {
                    stateMachine.EnterIn<SearchingTargetState>();
                }

                return;
            }

            if (IsOnAttackLine())
            {
                stateMachine.EnterIn<AttackState>();
                OnPursuit?.Invoke(entity.transform.position);

                return;
            }
            else
            {
                CheckLastPositionAndPursuit();
            }
        }

        private void CheckLastPositionAndPursuit()
        {
            lastTargetPos.value = target.value.position;
            OnPursuit.Invoke(lastTargetPos.value);            
        }
    }
}
