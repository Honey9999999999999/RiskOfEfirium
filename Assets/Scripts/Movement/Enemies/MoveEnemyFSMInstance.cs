using Assets.Scripts.Movement;
using FSM;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemyFSMInstance : FSMExample<EnemyMoveState>
{
    [SerializeField] private float _speed;

    [SerializeField] private Enemy _entity;
    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        _agent.speed = _speed;

        _stateMachine.AddState(new EnemyMoveStates.IdleState(_stateMachine, _entity, _agent));
        _stateMachine.AddState(new EnemyMoveStates.WalkState(_stateMachine, _entity, _agent));

        _stateMachine.EnterIn<EnemyMoveStates.IdleState>();
    }
}
