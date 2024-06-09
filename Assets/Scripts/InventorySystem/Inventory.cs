using Assets.Scripts.InventorySystem.Items;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class Inventory
    {
        private Dictionary<Type, Item> _itemsMap = new()
        {
            [typeof(MoveMod)] = new MoveMod()
        };

        public Inventory()
        {
            Item.OnResourceAdded += ApplyEffect;
            Item.OnResourceTaked += ReverseEffect;
        }

        public void AddItem<TItem>() where TItem : Item
        {
            _itemsMap[typeof(TItem)].amount += 1;
        }

        private void ApplyEffect(Item item)
        {
            _itemsMap[item.GetType()].Effect();
        }
        private void ReverseEffect(Item item)
        {
            _itemsMap[item.GetType()].ReverseEffect();
        }
    }
}
