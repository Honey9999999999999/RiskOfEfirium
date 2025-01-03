using Architecture;
using Assets.Scripts.InventorySystem;
using System;
using UnityEngine;

namespace Assets.Scripts.CraftSystem
{
    public class ItemCreator
    {
        public static event Action OnCrafted;

        private readonly Inventory _inventory;

        public ItemCreator()
        {
            _inventory = Game.GetInteractor<InventorySystemInteractor>().PlayerInventory;
        }

        public void Craft(Blueprint blueprint)
        {
            if (!IsContaintsAllComponents(blueprint))
            {
                Debug.Log("Not enough components...");
            }
            else
            {
                foreach (NamesOfDrop componentName in blueprint.Components.Keys)
                {
                    _inventory.RemoveItem(componentName, blueprint.Components[componentName]);
                }

                _inventory.AddItem(blueprint.ItemName);

                OnCrafted?.Invoke();
            }
        }

        public bool IsContaintsAllComponents(Blueprint blueprint)
        {
            foreach (NamesOfDrop componentName in blueprint.Components.Keys)
            {
                if (!_inventory.Contains(componentName, blueprint.Components[componentName]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
