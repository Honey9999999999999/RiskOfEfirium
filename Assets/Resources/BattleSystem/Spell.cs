using System.Collections;
using UnityEngine;

namespace Assets.Resources.BattleSystem
{
    public abstract class Spell : ScriptableObject
    {
        [SerializeField, Min(0)] float cooldownTime;

        protected Transform target;

        private float timer;
        private Coroutine reloadCoroutine;


        public SpellOrganaizer SpellOrganaizer { 
            get { return spellOrganaizer; } 
            set { spellOrganaizer = spellOrganaizer != null ? spellOrganaizer : value; } 
        }
        private SpellOrganaizer spellOrganaizer;

        public Transform LaunchPoint { 
            get { return launchPoint; }
            set { launchPoint = launchPoint != null ? launchPoint : value; }
        }
        private Transform launchPoint;

        public void Invoke(Transform target)
        {
            this.target = target;

            if (timer <= 0)
            {
                Do();
                reloadCoroutine = ReloadAsynk();
            }            
        }
        protected abstract void Do();

        private Coroutine ReloadAsynk()
        {
            timer = cooldownTime;
            return spellOrganaizer.StartCoroutine(ReloadRoutine());
        }

        private IEnumerator ReloadRoutine()
        {
            while(timer > 0)
            {
                timer -= Time.deltaTime;
                yield return null;
            }
        }
    }
}