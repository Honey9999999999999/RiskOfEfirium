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

        public PursuitTargetState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target, float attackDistance) : base(stateMachine, entity, target, attackDistance)
        {
        }

        Vector3 lastTargetPosition;

        public override void Enter()
        {
            base.Enter();

            if (!IsSeeTarget())
            {
                CheckLastPosition();
            }
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
                if(Vector3.Distance(lastTargetPosition, entity.transform.position) < 0.5f)
                {
                    stateMachine.EnterIn<SearchingTargetState>();
                }

                return;
            }
            else
            {
                CheckLastPosition();
            }

            if (IsOnAttackLine())
            {
                stateMachine.EnterIn<AttackState>();
                OnPursuit.Invoke(entity.transform.position);

                return;
            }
        }

        private void CheckLastPosition()
        {
            lastTargetPosition = target.value.position;
            OnPursuit.Invoke(lastTargetPosition);
        }
    }
}
