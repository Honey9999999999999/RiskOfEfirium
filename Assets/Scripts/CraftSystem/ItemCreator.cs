using Architecture;
using Assets.Scripts.InventorySystem;
using UnityEngine;

namespace Assets.Scripts.CraftSystem
{
    public class ItemCreator
    {
        private readonly Inventory _inventory;

        public ItemCreator()
        {
            _inventory = Game.GetInteractor<InventorySystemInteractor>().Inventory;
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
            }
        }

        private bool IsContaintsAllComponents(Blueprint blueprint)
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
