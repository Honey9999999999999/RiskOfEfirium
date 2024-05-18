using Assets.Scripts.Entities;
using System;
using UnityEngine;

[Serializable]
public class Enemy : LivingEntity
{
    protected override void OnDeath()
    {
        base.OnDeath();
    }
}
