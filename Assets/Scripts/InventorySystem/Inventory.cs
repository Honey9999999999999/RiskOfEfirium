using System;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class Inventory
    {
        private Dictionary<NamesOfDrop, Resource> _resourcesMap = new()
        {
            [NamesOfDrop.AlienResources] = new Resource(NamesOfDrop.AlienResources),
            [NamesOfDrop.ElectricResources] = new Resource(NamesOfDrop.ElectricResources),
            [NamesOfDrop.MechanicalResources] = new Resource(NamesOfDrop.MechanicalResources)
        };
        private Dictionary<Type, Item> _itemsMap = new()
        {
            [typeof(MoveMod)] = new MoveMod()
        };

        public Inventory()
        {
            Item.OnResourceAdded += ApplyEffect;
            Item.OnResourceTaked += ReverseEffect;
        }

        public void AddResource(NamesOfDrop name)
        {
            _resourcesMap[name].amount += 1;
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
