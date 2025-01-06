using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using PlayerMoveStates;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class MovePlayerFSMInstance : MoveFSMInstance<Player>
    {
        [SerializeField] private Transform _playerModel;
        [SerializeField, Min(0)] private float _baseSpeed;
        private ImprovedCharacteristic _speed;

        private void Awake()
        {
            if (_entity == null)
            {
                Game.OnGameInitialized += () => _entity = Game.GetInteractor<PlayerInteractor>().Player;
            }

            Initialize();
        }
        private void Start()
        {
            _speed = _entity.PersonalCCC.Get(Characteristics.Movespeed);

            _stateMachine.AddState(new IdleState(_stateMachine, _entity, _speed));
            _stateMachine.AddState(new WalkState(_stateMachine, _entity, _speed));
            _stateMachine.AddState(new FlyingState(_stateMachine, _entity, _playerModel, _speed));

            _stateMachine.EnterIn<IdleState>();
        }

        private void Initialize() { }

        public float GetBaseSpeed() => _baseSpeed;
    }
}
