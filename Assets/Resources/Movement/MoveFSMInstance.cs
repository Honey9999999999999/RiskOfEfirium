using Assets.Scripts.Entities;
using FSM;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public abstract class MoveFSMInstance<TEntity> : FSMExample<FSMMove, MoveState> where TEntity : LivingEntity
    {
        [SerializeField] protected TEntity entity;

        public virtual void EntityDead()
        {
            //_speed.value = 0;
        }
    }
}
