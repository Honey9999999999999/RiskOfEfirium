using System.Collections.Generic;
using Assets.Resources.CharacterStatsSystem;
using Assets.Scripts.CharacterStatsSystem;
using UnityEngine;

namespace Assets.Resources.BattleSystem.Zones
{
    public class BuffZone : Zone
    {
        [SerializeField] private List<Characteristics> characteristics;
        [SerializeField] private BuffType type;
        [SerializeField, Range(0, 1)] private float percent;
        [SerializeField, Min(0)] private float duration;

        protected override void Do()
        {
            foreach (var entity in entities)
            {
                if(type == BuffType.Buff && entity.Side == Side)
                {
                    foreach(var characteristic in characteristics)
                        entity.PersonalCCC.Get(characteristic).SetBuff(type, percent, duration);
                }
                else if (type == BuffType.DeBuff && entity.Side != Side)
                {
                    foreach (var characteristic in characteristics)
                        entity.PersonalCCC.Get(characteristic).SetBuff(type, percent, duration);
                }
            }
        }
    }
}