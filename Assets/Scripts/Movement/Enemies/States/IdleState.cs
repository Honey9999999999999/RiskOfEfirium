using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using FSM;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class IdleState : EnemyMoveState
    {
        public IdleState(FinalStateMachine<EnemyMoveState> stateMachine, Enemy entity, NavMeshAgent agent) : base(stateMachine, entity, agent)
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

            if (_controller.isTarget)
            {
                _stateMachine.EnterIn<WalkState>();
                return;
            }
        }
    }
}
