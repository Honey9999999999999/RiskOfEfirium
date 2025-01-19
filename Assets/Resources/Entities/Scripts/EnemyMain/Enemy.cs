using System;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.CraftSystem.PersonalCards;
using Assets.Scripts.Entities;
using UnityEngine;

[Serializable]
public class Enemy : LivingEntity
{
    [SerializeField] private MoveEnemyFSMInstance _moveInstance;

    public override CharacterCharacteristicCard PersonalCCC => blobCCC;
    private readonly BlobCCC blobCCC = new();

    public static event Action<Enemy> OnEnemyDeath;

    public MoveEnemyFSMInstance GetMoveInstance()
    {
        return _moveInstance;
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        _moveInstance.EntityDead();
        _entityController.enabled = false;

        OnEnemyDeath?.Invoke(this);
    }
}
