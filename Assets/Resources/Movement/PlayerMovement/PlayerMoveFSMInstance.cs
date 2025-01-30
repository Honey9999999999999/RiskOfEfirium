using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Entities;
using PlayerMoveStates;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    [RequireComponent(typeof(Rigidbody), typeof(LivingEntity))]
    public class PlayerMoveFSMInstance : MoveFSMInstance<Player>
    {
        [SerializeField] private Transform _playerModel;
        [SerializeField, Min(0)] private float _baseSpeed;
        private ImprovedCharacteristic _speed;

        private void Awake()
        {
            if (entity == null)
            {
                Game.OnGameInitialized += () => entity = Game.GetInteractor<PlayerInteractor>().Player;
            }

            Initialize();
        }
        private void Start()
        {
            _speed = entity.PersonalCCC.Get(Characteristics.Movespeed);

            stateMachine.AddState(new IdleState(stateMachine, entity, _speed));
            stateMachine.AddState(new WalkState(stateMachine, entity, _speed));
            stateMachine.AddState(new FlyingState(stateMachine, entity, _playerModel, _speed));

            stateMachine.EnterIn<IdleState>();
        }

        private void Initialize() { }

        public float GetBaseSpeed() => _baseSpeed;
    }
}
