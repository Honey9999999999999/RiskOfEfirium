using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using EnemyMoveStates;
using EntityControllers;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMovement
{
    public class EnemyMoveFSMInstance : MoveFSMInstance<Enemy>
    {
        [SerializeField] private EnemyBattleFSMInstance enemyBattler;
        [SerializeField] private NavMeshAgent agent;

        [SerializeField] private ShellValue<Vector3> followPosition;
        [SerializeField] private ShellValue<Vector3> trackingPosition;

        private void Start()
        {
            followPosition = new()
            {
                value = transform.position
            };
            trackingPosition = new()
            {
                value = transform.position
            };
            ImprovedCharacteristic speed = entity.PersonalCCC.Get(Characteristics.Movespeed);

            stateMachine.AddState(new IdleState(stateMachine, agent, followPosition, trackingPosition, speed));
            stateMachine.AddState(new WalkState(stateMachine, agent, followPosition, trackingPosition, speed));
            stateMachine.AddState(new RotateState(stateMachine, agent, followPosition, trackingPosition, speed));

            enemyBattler.OnAttack += (invoker, target) => trackingPosition.value = target.position;
            enemyBattler.OnChangeTargetPos += (position) => followPosition.value = position;
            entity.OnEntityDeath += () =>
            {
                stateMachine.currentState.Exit();
                enabled = false;
            };

            stateMachine.EnterIn<IdleState>();
        }
    }
}