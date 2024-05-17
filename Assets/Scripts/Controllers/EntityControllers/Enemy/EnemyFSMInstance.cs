using Assets.Scripts.Controllers.EntityControllers.Enemy.States;
using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy
{
    [RequireComponent(typeof(Collider), typeof(NavMeshAgent))]
    public class EnemyFSMInstance : FSMExample<EnemyState>
    {
        [SerializeField] private LivingEntity _entity;
        [SerializeField] private ShellValue<Transform> _target;

        public bool isTarget => _target.value != null;

        private void Start()
        {
            _target = new();

            _stateMachine.AddState(new SearchingTargetState(_stateMachine, _entity, _target));
            _stateMachine.AddState(new PursuitTarget(_stateMachine, _entity, _target));

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
