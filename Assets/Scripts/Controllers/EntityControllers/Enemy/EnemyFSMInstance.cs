using Assets.Scripts.Controllers.EntityControllers.Enemy.States;
using FSM;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers.EntityControllers.Enemy
{
    [RequireComponent(typeof(Collider), typeof(NavMeshAgent))]
    public class EnemyFSMInstance : FSMExample<EnemyState>
    {
        private Collider _target;

        public bool isTarget => _target != null;

        private void Start()
        {
            _stateMachine.AddState(new SearchingTargetState(_stateMachine, _target));
            _stateMachine.AddState(new PursuitTarget(_stateMachine, _target));

            _stateMachine.EnterIn<SearchingTargetState>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                _target = other;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.TryGetComponent<Player>(out _))
            {
                _target = null;
            }
        }

        public Vector3 GetDirectionToTarget()
        {
            return _stateMachine.currentState.GetDirectionToTarget().normalized;
        }
    }
}
