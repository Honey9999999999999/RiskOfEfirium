using System;
using System.Collections.Generic;
using Assets.Scripts.Entities;
using EntityControllers;
using UnityEngine;

namespace Assets.Resources.BattleSystem
{
    public class SpellOrganaizer : MonoBehaviour
    {
        public event Action<Spell> OnNextSpell;
        public event Action<float> OnCoolDown;

        [SerializeField] private EnemyBattleFSMInstance enemyBattleFSM;
        [SerializeField] private List<Spell> spells;
        [SerializeField] private List<Transform> startPosSpells;

        [SerializeField] private float generalCooldown;

        private Spell preparedSpell;

        private void Start()
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i] = Instantiate(spells[i]);
                spells[i].SpellOrganaizer = this;
                spells[i].LaunchPoint = startPosSpells[i];
                spells[i].OnReady += PrepareFirst;
            }
            enemyBattleFSM.OnAttack += (invoker, target) =>
            {
                if (TryInvokePrepareSpell(invoker, target))
                {
                    PrepareSpell();
                    OnCoolDown?.Invoke(generalCooldown);
                }
            };

            PrepareSpell();
        }

        public Transform GetTransform() => enemyBattleFSM.transform;

        public bool TryInvokePrepareSpell(LivingEntity invoker, Transform target)
        {
            if (preparedSpell != null && preparedSpell.IsReady)
            {
                preparedSpell.Invoke(invoker, target);
                return true;
            }
            return false;
        }

        private void PrepareSpell()
        {
            List<Spell> readySpells = new();

            foreach (Spell spell in spells)
            {
                if (spell.IsReady)
                {
                    readySpells.Add(spell);
                }
            }

            System.Random random = new();
            preparedSpell = readySpells.Count > 0 ? readySpells[random.Next(readySpells.Count)] : preparedSpell;

            OnNextSpell?.Invoke(preparedSpell);
        }

        private void PrepareFirst(Spell spell) => preparedSpell = preparedSpell.IsReady ? preparedSpell : spell;
    }
}
