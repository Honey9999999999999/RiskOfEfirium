using System.Collections;
using MyTimer;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Spells
{
    [CreateAssetMenu(fileName = "DirectedSpell", menuName = "BattleSystem/EnemySpells/DirectedSpell")]
    public class DirectedSpell : Spell
    {
        [Space]
        [SerializeField] private GameObject projectilePrefab;

        [Space]
        [SerializeField] private float projectileSpeed;
        [SerializeField] private AnimationCurve projectileTrajectory;

        private Coroutine coroutine;

        protected override void Do()
        {
            coroutine = StartProjectile();
        }

        private Coroutine StartProjectile()
        {
            return SpellOrganaizer.StartCoroutine(ProjectileFlightRoutine());
        }
        private IEnumerator ProjectileFlightRoutine()
        {
            GameObject projecileClone = Instantiate(projectilePrefab);

            Vector3 startPos = LaunchPoint == null ? SpellOrganaizer.GetTransform().position : LaunchPoint.position;
            Vector3 endPos = target.TryGetComponent(out Collider collider) ? collider.bounds.center : target.position;
            Vector3 oldPos = startPos;

            float timeFlight = Vector3.Distance(startPos, endPos) / projectileSpeed;
            float timer = timeFlight;

            while (timer > 0)
            {
                oldPos = projecileClone.transform.position;

                float time = timer / timeFlight;
                projecileClone.transform.position = Vector3.Lerp(endPos, startPos, time);
                projecileClone.transform.position += new Vector3(0, projectileTrajectory.Evaluate(time), 0);                

                timer -= Time.deltaTime;

                yield return null;                
            }

            if (projecileClone.TryGetComponent(out Rigidbody rb))
            {
                rb.velocity = (projecileClone.transform.position - oldPos).normalized * projectileSpeed;
            }
        }
    }
}