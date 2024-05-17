using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy.States
{
    public class PursuitTarget : EnemyState
    {
        public PursuitTarget(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target) : base(stateMachine, entity, target)
        {
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Pursuit target");
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
        }
    }
}
