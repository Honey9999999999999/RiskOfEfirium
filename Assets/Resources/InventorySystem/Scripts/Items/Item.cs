using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Tools;
using Interfaces;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class Item : ResourceBase<Item>, IEffecter
    {
        public abstract ItemNames Name { get; }
        public abstract Dictionary<Characteristics, float> ImprovedCharacteristicsMap { get; }

        public virtual void Effect(CharacterCharacteristicCard personalCCC)
        {
            foreach (var key in ImprovedCharacteristicsMap.Keys)
            {
                personalCCC.ChangeOf(key, ImprovedCharacteristicsMap[key]);
            }
        }
        public virtual void ReverseEffect(CharacterCharacteristicCard personalCCC)
        {
            foreach (var key in ImprovedCharacteristicsMap.Keys)
            {
                personalCCC.ChangeOf(key, -ImprovedCharacteristicsMap[key]);
            }
        }
    }
}
