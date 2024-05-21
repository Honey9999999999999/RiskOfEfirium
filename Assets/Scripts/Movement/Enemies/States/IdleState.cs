using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMoveStates
{
    internal class IdleState : EnemyMoveState
    {
        public IdleState(FSMMove stateMachine, Enemy entity, NavMeshAgent agent, ShellValue<float> speed) : base(stateMachine, entity, agent, speed)
        {
        }

        public override void Enter()
        {
            base.Enter();

            _rigidbody.velocity = Vector3.zero;
            _agent.speed = 0;
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (_controller.isWalk)
            {
                _stateMachine.EnterIn<WalkState>();
                return;
            }
        }
    }
}
