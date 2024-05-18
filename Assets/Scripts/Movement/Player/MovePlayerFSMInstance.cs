using Assets.Scripts.Entities;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class MovePlayerFSMInstance : MoveFSMInstance<PlayerMoveState>
    {
        [SerializeField] private Player _entity;
        private void Awake()
        {
            if(_entity == null)
            {
                _entity = gameObject.GetComponent<Player>();
            }
        }
        private void Start()
        {
            _stateMachine.AddState(new IdleState(_stateMachine, _entity, _speed));
            _stateMachine.AddState(new WalkState(_stateMachine, _entity, _speed));

            _stateMachine.EnterIn<IdleState>();
        }
    }
}
