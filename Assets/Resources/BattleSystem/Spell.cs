using System;
using System.Collections;
using Assets.Scripts.Entities;
using UnityEngine;

namespace Assets.Resources.BattleSystem
{
    public abstract class Spell : ScriptableObject
    {
        public event Action<Spell> OnReady;

        [SerializeField, Min(0)] private float cooldownTime;
        [SerializeField, Min(0)] private float rangeApplycation;

        protected LivingEntity invoker;
        protected Transform target;

        private float timer;
        private Coroutine reloadCoroutine;

        public bool IsReady => timer <= 0;


        public SpellOrganaizer SpellOrganaizer
        {
            get { return spellOrganaizer; }
            set
            {
                if (spellOrganaizer == null)
                {
                    spellOrganaizer = value;
                    spellOrganaizer.OnCoolDown += (cooldown) =>
                    {
                        if (timer <= 0)
                        {
                            reloadCoroutine = ReloadAsynk(cooldown);
                        }
                        else
                        {
                            timer = timer >= cooldown ? timer : cooldown;
                        }
                    };
                }
                spellOrganaizer = spellOrganaizer != null ? spellOrganaizer : value;
            }
        }
        private SpellOrganaizer spellOrganaizer;

        public Transform LaunchPoint
        {
            get { return launchPoint; }
            set { launchPoint = launchPoint != null ? launchPoint : value; }
        }
        private Transform launchPoint;

        public void Invoke(LivingEntity invoker, Transform target)
        {
            this.invoker = invoker;
            this.target = target;

            if (IsReady)
            {
                Do();
                reloadCoroutine = ReloadAsynk(cooldownTime);
            }
        }
        protected abstract void Do();

        private Coroutine ReloadAsynk(float time)
        {
            timer = time;
            return spellOrganaizer.StartCoroutine(ReloadRoutine());
        }
        private IEnumerator ReloadRoutine()
        {
            while (timer > 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }

            OnReady?.Invoke(this);
        }

        public float GetRangeApplycation() => rangeApplycation;
    }
}