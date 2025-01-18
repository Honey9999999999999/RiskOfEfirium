using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using UnityEngine;
using UnityEngine.AI;

public class MoveEnemyFSMInstance : MoveFSMInstance<Enemy>
{
    [SerializeField] private NavMeshAgent _agent;

    private void Start()
    {
        ImprovedCharacteristic speed = _entity.PersonalCCC.Get(Characteristics.Movespeed);

        _stateMachine.AddState(new EnemyMoveStates.IdleState(_stateMachine, _entity, _agent, speed));
        _stateMachine.AddState(new EnemyMoveStates.WalkState(_stateMachine, _entity, _agent, speed));

        _stateMachine.EnterIn<EnemyMoveStates.IdleState>();
    }
}
