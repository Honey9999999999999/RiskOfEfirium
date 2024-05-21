using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Tools;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public class PlayerMoveState : MoveState
    {
        protected Player _entity;
        protected PlayerController _controller;
        protected Rigidbody _rigidbody;
        public PlayerMoveState(FSMMove stateMachine, Player entity, ShellValue<float> speed) : base(stateMachine, speed)
        {
            _entity = entity;
            _controller = (PlayerController)_entity.GetEntityController();
            _rigidbody = _entity.GetRigidbody();
        }
    }
}
