using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Controllers.EntityControllers.EnemyController.States;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;
using UnityEngine.AI;
using WeaponSystem;

namespace EntityControllers
{
    [RequireComponent(typeof(Collider), typeof(NavMeshAgent))]
    public class EnemyBattleFSMInstance : FSMExample<FSMEnemy, EnemyState>
    {
        [SerializeField] private Enemy _entity;
        [SerializeField] private ShellValue<Transform> _target;
        [SerializeField] private float _attackDistance;
        [SerializeField] private Gun _gun;

        public bool isTarget => _target.value != null;

        private void Start()
        {
            _entity.OnEntityDeath += () =>
            {
                _stateMachine.currentState.Exit();
                enabled = false;
            };

            _target = new();

            _stateMachine.AddState(new SearchingTargetState(_stateMachine, _entity, _target));
            _stateMachine.AddState(new PursuitTargetState(_stateMachine, _entity, _target, _attackDistance));
            _stateMachine.AddState(new AttackState(_stateMachine, _entity, _target, _attackDistance, _gun));

            _stateMachine.EnterIn<SearchingTargetState>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                _target.value = other.gameObject.transform;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                _target.value = null;
            }
        }

        public Transform GetTarget()
        {
            return _target.value;
        }
        public Vector3 GetTargetPosition()
        {
            return _stateMachine.currentState.GetTargetPosition();
        }
    }
}
