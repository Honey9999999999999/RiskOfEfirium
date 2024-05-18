using Architecture;
using Assets.Scripts.Entities;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class MovePlayerFSMInstance : MoveFSMInstance<Player>
    {
        private void Awake()
        {
            if(_entity == null)
            {
                Game.OnGameInitialized += () => _entity = Game.GetInteractor<PlayerInteractor>().player;
            }
        }
        private void Start()
        {
            Debug.Log(_stateMachine == null);
            _stateMachine.AddState(new IdleState(_stateMachine, _entity, _speed));
            _stateMachine.AddState(new WalkState(_stateMachine, _entity, _speed));

            _stateMachine.EnterIn<IdleState>();
        }
    }
}
