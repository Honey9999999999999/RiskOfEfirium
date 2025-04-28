using System.Collections;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Spells
{
    [CreateAssetMenu(fileName = "DirectedProjectileSpell", menuName = "BattleSystem/EnemySpells/DirectedProjectileSpell")]
    public class DirectedProjectileSpell : Spell
    {
        private enum Direction
        {
            Forward,
            Back,
            Left,
            Right
        }

        [Space]
        [SerializeField] private Projectile projectilePrefab;

        [Space]
        [SerializeField, Min(1)] private int amount;
        [SerializeField] private float speed;

        [Space]
        [SerializeField, Min(0)] private float angleSpread;

        [Space]
        [SerializeField] Direction direction;

        protected override void Do()
        {
            Transform transform = SpellOrganaizer.GetTransform();
            Vector3 direction = this.direction switch
            {
                Direction.Forward => invoker.transform.forward,
                Direction.Back => invoker.transform.forward * -1,
                Direction.Left => invoker.transform.right * -1,
                Direction.Right => invoker.transform.right,
                _ => Vector3.zero,
            };

            if (amount > 1)
            {
                float radSpread = angleSpread * Mathf.PI / 180;
                float halfRadSpread = radSpread / 2;
                float stepRadSpread = radSpread / amount;

                direction = RotateVector(direction, -halfRadSpread);

                for (int i = 0; i < amount; i++)
                {
                    Projectile projectileClone = Instantiate(projectilePrefab);
                    projectileClone.FlightCoroutine = StartProjectile(projectileClone, direction);

                    direction = RotateVector(direction, stepRadSpread);
                }
            }
            else
            {
                Projectile projectileClone = Instantiate(projectilePrefab);                
                projectileClone.FlightCoroutine = StartProjectile(projectileClone, direction);
            }            
        }

        private Vector3 RotateVector(Vector3 original, float radians)
        {
            Quaternion rotation = Quaternion.Euler(0, radians * Mathf.Rad2Deg, 0);
            return rotation * original;
        }

        private Coroutine StartProjectile(Projectile projectileClone, Vector3 direction)
        {
            projectileClone.Invoker = invoker;
            projectileClone.Side = Scripts.Entities.Side.Enemies;
            return projectileClone.StartCoroutine(ProjectileFlightRoutine(projectileClone, direction));
        }

        private IEnumerator ProjectileFlightRoutine(Projectile projectile, Vector3 direction)
        {

            if (projectile.TryGetComponent(out Rigidbody rb))
            {
                rb.useGravity = false;
            }

            Vector3 startPos = LaunchPoint == null ? SpellOrganaizer.GetTransform().position : LaunchPoint.position;
            Vector3 endPos;

            if(Physics.Raycast(startPos, direction, out RaycastHit hitInfo, 99, (1 << 8) | (1 << 9) | (1 << 10), QueryTriggerInteraction.Ignore))
            {
                endPos = hitInfo.point;
            }
            else
            {
                endPos = startPos + direction * 99;
            }

            Vector3 oldPos = startPos;

            float distance = Vector3.Distance(startPos, endPos);
            float timeFlight = distance / speed;
            float timer = timeFlight;

            while (timer > 0)
            {
                float time = timer / timeFlight;

                oldPos = projectile.transform.position;
                projectile.transform.position = Vector3.Lerp(endPos, startPos, time);

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