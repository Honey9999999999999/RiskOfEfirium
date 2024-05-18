using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public abstract class MoveFSMInstance<TMoveState> : FSMExample<TMoveState> where TMoveState : IState
    {
        [SerializeField] protected ShellValue<float> _speed;

        public virtual void EntityDead()
        {
            _speed.value = 0;
        }
    }
}
