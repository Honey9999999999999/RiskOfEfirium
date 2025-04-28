using System;
using Assets.Resources.ArmorSystem.Scripts;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Zones
{
    [Serializable]
    public class DamageZone : Zone
    {
        [SerializeField, Min(0)] private float baseDamagePerTick;
        [SerializeField] private TypeDamage type;

        protected override void Do()
        {
            foreach (var entity in entities)
            {
                if (entity.Side != Side)
                {
                    entity.TakenDamage(type, baseDamagePerTick);
                }
            }
        }
    }
}