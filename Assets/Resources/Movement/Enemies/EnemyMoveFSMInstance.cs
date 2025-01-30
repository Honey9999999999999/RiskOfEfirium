using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Movement;
using Assets.Scripts.Tools;
using EntityControllers;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

namespace EnemyMovement
{
    public class EnemyMoveFSMInstance : MoveFSMInstance<Enemy>
    {
        [SerializeField] private EnemyBattleFSMInstance enemyBattler;
        [SerializeField] private NavMeshAgent agent;

        public ShellValue<Vector3> TargetPosition { get; private set; }

        private void Start()
        {
            TargetPosition = new();
            ImprovedCharacteristic speed = entity.PersonalCCC.Get(Characteristics.Movespeed);

            stateMachine.AddState(new EnemyMoveStates.IdleState(stateMachine, agent, TargetPosition, speed));
            stateMachine.AddState(new EnemyMoveStates.WalkState(stateMachine, agent, TargetPosition, speed));
            stateMachine.AddState(new EnemyMoveStates.RotateState(stateMachine, agent, TargetPosition, speed));

            enemyBattler.OnChangeTargetPos += (position) => TargetPosition.value = position;
            entity.OnEntityDeath += () => 
            {
                stateMachine.currentState.Exit();
                enabled = false;
            };

            stateMachine.EnterIn<EnemyMoveStates.IdleState>();
        }
    }
}