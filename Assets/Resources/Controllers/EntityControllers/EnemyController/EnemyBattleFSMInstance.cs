using System;
using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Controllers.EntityControllers.EnemyController.States;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace EntityControllers
{
    [RequireComponent(typeof(Collider), typeof(NavMeshAgent))]
    public class EnemyBattleFSMInstance : FSMExample<FSMEnemy, EnemyState>
    {
        public event Action<Vector3> OnChangeTargetPos;
        public event Action<Transform> OnAttack;

        [SerializeField] private Enemy entity;
        [SerializeField] private ShellValue<Transform> target;
        [SerializeField, Min(0)] private float attackDistance;

        public Transform Target => target.value != null ? target.value : throw new Exception("Target is exist (Null Reference exception)");

        private void Start()
        {
            target = new();

            stateMachine.AddState(new SearchingTargetState(stateMachine, entity, target));
            stateMachine.AddState(new PursuitTargetState(stateMachine, entity, target, attackDistance));
            stateMachine.AddState(new AttackState(stateMachine, entity, target, attackDistance));

            ((SearchingTargetState)stateMachine.GetState<SearchingTargetState>()).OnExplore += (position) => OnChangeTargetPos?.Invoke(position);
            ((PursuitTargetState)stateMachine.GetState<PursuitTargetState>()).OnPursuit += (position) => OnChangeTargetPos?.Invoke(position);
            ((AttackState)stateMachine.GetState<AttackState>()).OnAttack += (target) => OnAttack?.Invoke(target);
            
            entity.OnEntityDeath += () =>
            {
                stateMachine.currentState.Exit();
                enabled = false;
            };

            stateMachine.EnterIn<SearchingTargetState>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                target.value = other.gameObject.transform;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                target.value = null;
            }
        }
    }
}
