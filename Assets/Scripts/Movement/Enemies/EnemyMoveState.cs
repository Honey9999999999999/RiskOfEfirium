using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using UnityEngine.AI;

namespace Assets.Scripts.Movement
{
    public abstract class EnemyMoveState : MoveState<EnemyMoveState, Enemy, EnemyController>
    {
        protected NavMeshAgent _agent;

        protected EnemyMoveState(FinalStateMachine<EnemyMoveState> stateMachine, Enemy entity, NavMeshAgent agent, ShellValue<float> speed) : base(stateMachine, entity, speed)
        {
            _agent = agent;
        }
    }
}
