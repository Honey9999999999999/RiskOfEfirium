using System.Collections.Generic;
using EntityControllers;
using UnityEngine;

namespace Assets.Resources.BattleSystem
{
    public class SpellOrganaizer : MonoBehaviour
    {
        [SerializeField] private EnemyBattleFSMInstance enemyBattleFSM;
        [SerializeField] private List<Spell> spells;
        [SerializeField] private List<Transform> startPosSpells;

        private void Start()
        {
            for (int i = 0; i < spells.Count; i++)
            {
                spells[i] = Instantiate(spells[i]);
                spells[i].SpellOrganaizer = this;
                spells[i].LaunchPoint = startPosSpells[i];
            }
            enemyBattleFSM.OnAttack += (target) => ApplySkill(0, target);
        }

        public Transform GetTransform() => enemyBattleFSM.transform;

        public void ApplySkill(int index, Transform target)
        {
            spells[index].Invoke(target);
        }
    }
}
