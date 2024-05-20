using Architecture;
using Assets.Scripts.Entities;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class MovePlayerFSMInstance : MoveFSMInstance<Player>
    {
        [SerializeField, Min(0)] private float _baseSpeed;

        private void Awake()
        {
            if(_entity == null)
            {
                Game.OnGameInitialized += () => _entity = Game.GetInteractor<PlayerInteractor>().player;                
            }

            Initialize();
        }
        private void Start()
        {
            Debug.Log(_stateMachine == null);
            _stateMachine.AddState(new IdleState(_stateMachine, _entity, _speed));
            _stateMachine.AddState(new WalkState(_stateMachine, _entity, _speed));

            _stateMachine.EnterIn<IdleState>();
        }

        private void Initialize()
        {
            _speed.value = _baseSpeed;
        }

        public float GetBaseSpeed() => _baseSpeed;
        public void SetSpeed(float value)
        {
            if(value >= 0)
            {
                _speed.value = value;
            }
        }
    }
}
