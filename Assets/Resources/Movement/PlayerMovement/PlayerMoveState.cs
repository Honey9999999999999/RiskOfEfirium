using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Controllers.EntityControllers;
using PlayerMoveStates;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class PlayerMoveState : MoveState
    {
        protected Player _entity;
        protected PlayerController _controller;
        protected Rigidbody _rigidbody;
        protected PlayerInteractor _playerInteractor;

        public PlayerMoveState(FSMMove stateMachine, Player entity, ImprovedCharacteristic speed) : base(stateMachine, speed)
        {
            _entity = entity;
            _controller = (PlayerController)_entity.GetEntityController();
            _rigidbody = _entity.GetRigidbody();

            _playerInteractor = Game.GetInteractor<PlayerInteractor>();
            _playerInteractor.OnMenuOpened += () => base.stateMachine.EnterIn<IdleState>();
        }
    }
}
