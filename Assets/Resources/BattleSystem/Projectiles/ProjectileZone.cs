using Assets.Resources.BattleSystem.Zones;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Projectiles
{
    public class ProjectileZone : Projectile
    {
        [SerializeField] private Zone zone;

        protected override void Do(Collider other)
        {
            Zone clone = Instantiate(zone);
            clone.transform.position = transform.position;
            clone.Side = Side;
        }
    }
}