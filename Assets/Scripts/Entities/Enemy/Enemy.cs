using Assets.Scripts.Entities;
using System;
using UnityEngine;

[Serializable]
public class Enemy : LivingEntity
{
    [SerializeField] private MoveEnemyFSMInstance _moveInstance;

    protected override void OnDeath()
    {
        base.OnDeath();

        _moveInstance.EntityDead();
    }
}
