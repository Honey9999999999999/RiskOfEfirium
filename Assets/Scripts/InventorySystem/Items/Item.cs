using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Tools;
using Interfaces;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class Item : ResourceBase<Item>, IEffecter
    {
        public abstract NamesOfDrop Name { get; }
        public abstract Dictionary<Characteristics, float> ImprovedCharacteristicsMap { get; }
        protected readonly CharacterCharacteristicCard personalCCC;

        public Item(CharacterCharacteristicCard personalCCC)
        {
            this.personalCCC = personalCCC;
        }

        public virtual void Effect()
        {
            foreach (var key in ImprovedCharacteristicsMap.Keys)
            {
                personalCCC.ChangeOf(key, ImprovedCharacteristicsMap[key]);
            }
        }
        public virtual void ReverseEffect()
        {
            foreach (var key in ImprovedCharacteristicsMap.Keys)
            {
                personalCCC.ChangeOf(key, -ImprovedCharacteristicsMap[key]);
            }
        }
    }
}
