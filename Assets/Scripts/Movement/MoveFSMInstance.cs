using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public abstract class MoveFSMInstance<TEntity> : FSMExample<FSMMove, MoveState> where TEntity : LivingEntity
    {
        [SerializeField] protected TEntity _entity;
        [SerializeField] protected ShellValue<float> _speed;

        public virtual void EntityDead()
        {
            _speed.value = 0;
        }
    }
}
