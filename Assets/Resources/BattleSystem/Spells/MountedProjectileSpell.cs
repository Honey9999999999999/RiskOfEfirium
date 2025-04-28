using System.Collections;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Spells
{
    [CreateAssetMenu(fileName = "MountedProjectileSpell", menuName = "BattleSystem/EnemySpells/MountedProjectileSpell")]
    public class MountedProjectileSpell : Spell
    {
        [Space]
        [SerializeField] private Projectile projectilePrefab;

        [Space]
        [SerializeField, Min(1)] private int amount;
        [SerializeField] private float speed;
        [SerializeField, Min(0)] private float spread;
        [SerializeField] private AnimationCurve projectileTrajectory;

        protected override void Do()
        {
            for (int i = 0; i < amount; i++)
            {
                Projectile projectileClone = Instantiate(projectilePrefab);
                projectileClone.Side = Scripts.Entities.Side.Enemies;
                projectileClone.FlightCoroutine = StartProjectile(projectileClone);
            }
        }

        private Coroutine StartProjectile(Projectile projectile)
        {
            projectile.Invoker = invoker;
            return projectile.StartCoroutine(ProjectileFlightRoutine(projectile));
        }
        private IEnumerator ProjectileFlightRoutine(Projectile projectile)
        {
            if (projectile.TryGetComponent(out Rigidbody rb))
            {
                rb.useGravity = false;
            }

            Vector3 startPos = LaunchPoint == null ? SpellOrganaizer.GetTransform().position : LaunchPoint.position;
            Vector3 endPos = target.TryGetComponent(out Collider collider) ? collider.bounds.center : target.position;
            Vector3 oldPos = startPos;

            float distance = Vector3.Distance(startPos, endPos);
            float timeFlight = distance / speed;
            float timer = timeFlight;

            float spreadByDistance = spread * distance;
            endPos += new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).
                normalized * Random.Range(-spreadByDistance, spreadByDistance);
            distance = Vector3.Distance(startPos, endPos);

            while (timer > 0)
            {
                float time = timer / timeFlight;

                oldPos = projectile.transform.position;
                projectile.transform.position = Vector3.Lerp(endPos, startPos, time);
                projectile.transform.position += new Vector3(0, projectileTrajectory.Evaluate(1 - time) * distance, 0);

                timer -= Time.deltaTime;

                yield return null;
            }

            if (rb != null)
            {
                rb.useGravity = true;
                rb.velocity = (projectile.transform.position - oldPos) / Time.deltaTime;
            }
        }
    }
}