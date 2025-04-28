using Assets.Resources.ArmorSystem.Scripts;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Projectiles
{
    public class DamageProjectile : Projectile
    {
        [Space]
        [SerializeField, Min(0)] private float baseDamage;
        [SerializeField] private TypeDamage type;

        protected override void Do(Collider other)
        {
            if (other.TryGetComponent(out LivingEntity entity) && entity.Side != Side)
            {
                entity.TakenDamage(type, baseDamage/* * ccc.*/);
            }
        }
    }
}