using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.CraftSystem.Blueprints;
using Assets.Scripts.InventorySystem.Items;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class Inventory
    {
        public event Action<Blueprint> OnBlueprintAdded;
        public List<Blueprint> Blueprints { get; }

        private readonly Dictionary<NamesOfDrop, Item> _itemsMap;


        public Inventory(CharacterCharacteristicCard personalCCC)
        {
            _itemsMap = new()
            {
                [NamesOfDrop.AlienResources] = new AlienResource(),
                [NamesOfDrop.ElectricResources] = new ElectricResource(),
                [NamesOfDrop.MechanicalResources] = new MechanicalResource(),

                [NamesOfDrop.SyneticMuscles] = new SyneticMuscles(personalCCC),
                [NamesOfDrop.Thermostat] = new Thermostat(personalCCC),
                [NamesOfDrop.ImprovedLaserBattery] = new ImprovedLaserBattery(personalCCC)
            };

            foreach (var key in _itemsMap.Keys)
            {
                _itemsMap[key].OnResourceAdded += ApplyEffect;
                _itemsMap[key].OnResourceTaked += ReverseEffect;
            }

            Blueprints = new()
            {
                new ThermostatBlueprint(),
                new ImprovedLaserBatteryBlueprint(),
                new SyneticMusclesBlueprint()
            };
        }
        public void AddItem(NamesOfDrop dropName)
        {
            _itemsMap[dropName].amount += 1;
        }
        public void RemoveItem(NamesOfDrop dropName, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RemoveItem(dropName);
            }
        }
        public void RemoveItem(NamesOfDrop dropName)
        {
            _itemsMap[dropName].amount -= 1;
        }

        public void AddBlueprint(Blueprint blueprint)
        {
            if (Blueprints.Contains(blueprint)) return;

            Blueprints.Add(blueprint);
            OnBlueprintAdded?.Invoke(blueprint);
        }

        private void ApplyEffect(Item item)
        {
            _itemsMap[item.Name].Effect();
        }
        private void ReverseEffect(Item item)
        {
            _itemsMap[item.Name].ReverseEffect();
        }

        public bool Contains(Dictionary<NamesOfDrop, int> items)
        {
            foreach (var name in items.Keys)
            {
                if (!Contains(name, items[name]))
                {
                    return false;
                }
            }

            return true;
        }
        public bool Contains(NamesOfDrop dropName, int count)
        {
            return _itemsMap.ContainsKey(dropName) && _itemsMap[dropName].amount >= count;
        }

        public Item GetItem(NamesOfDrop name) => _itemsMap[name];
    }
}
