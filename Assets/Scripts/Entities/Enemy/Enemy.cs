using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using System;
using UnityEngine;

[Serializable]
public class Enemy : LivingEntity
{
    [SerializeField] private MoveEnemyFSMInstance _moveInstance;
    public static event Action<Enemy> OnEnemyDeath;

    public MoveEnemyFSMInstance GetMoveInstance()
    {
        return _moveInstance;
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        _moveInstance.EntityDead();
        OnEnemyDeath?.Invoke(this);
    }
}
