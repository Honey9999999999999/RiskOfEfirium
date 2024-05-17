using Architecture;
using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy.States
{
    public class SearchingTargetState : EnemyState
    {
        public SearchingTargetState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target) : base(stateMachine, entity, target)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Serching target");
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (_target.value != null)
            {
                _stateMachine.EnterIn<PursuitTarget>();

                return;
            }
            else
            {
                _targetPosition = _entity.transform.position;         
            }
        }
    }
}