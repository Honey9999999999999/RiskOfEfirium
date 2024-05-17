using FSM;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy.States
{
    public class PursuitTarget : EnemyState
    {
        public PursuitTarget(FinalStateMachine<EnemyState> stateMachine, Collider target) : base(stateMachine, target)
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

            if(_target == null)
            {
                _stateMachine.EnterIn<SearchingTargetState>();

                return;
            }
            else
            {
                _targetPosition = _target.transform.position;
            }
        }
    }
}
