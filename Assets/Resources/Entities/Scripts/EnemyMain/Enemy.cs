using System;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.CraftSystem.PersonalCards;
using Assets.Scripts.Entities;

[Serializable]
public class Enemy : LivingEntity
{
    public override CharacterCharacteristicCard PersonalCCC => blobCCC;
    private readonly BlobCCC blobCCC = new();

    public static event Action<Enemy> OnEnemyDeath;

    protected override void OnDeath()
    {
        base.OnDeath();

        OnEnemyDeath?.Invoke(this);
    }
}
