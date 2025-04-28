using System;
using Assets.Resources.BattleSystem;
using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Controllers.EntityControllers.EnemyController.States;
using Assets.Scripts.Entities;
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
        public event Action<LivingEntity, Transform> OnAttack;

        [SerializeField] private Enemy entity;
        [SerializeField] private ShellValue<Transform> target;
        [SerializeField] private ShellValue<Vector3> lastTargetPos;
        [SerializeField] private ShellValue<float> attackDistance;

        [SerializeField] private SpellOrganaizer spellOrganaizer;

        public Transform Target => target.value != null ? target.value : throw new Exception("Target is exist (Null Reference exception)");

        private void Start()
        {
            target = new();

            stateMachine.AddState(new SearchingTargetState(stateMachine, entity, target));
            stateMachine.AddState(new PursuitTargetState(stateMachine, entity, target, lastTargetPos, attackDistance));
            stateMachine.AddState(new AttackState(stateMachine, entity, target, lastTargetPos, attackDistance));

            ((SearchingTargetState)stateMachine.GetState<SearchingTargetState>()).OnExplore += (position) => OnChangeTargetPos?.Invoke(position);
            ((PursuitTargetState)stateMachine.GetState<PursuitTargetState>()).OnPursuit += (position) => OnChangeTargetPos?.Invoke(position);
            ((AttackState)stateMachine.GetState<AttackState>()).OnAttack += (target) => OnAttack?.Invoke(entity, target);

            entity.OnEntityDeath += () =>
            {
                stateMachine.currentState.Exit();
                enabled = false;
            };

            if (spellOrganaizer != null)
            {
                spellOrganaizer.OnNextSpell += (spell) => attackDistance.value = spell.GetRangeApplycation();
            }

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
