using System.Collections.Generic;
using Assets.Resources.InventorySystem.Scripts.Items;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem.Items;

namespace Assets.Scripts.InventorySystem
{
    public class Inventory
    {
        private readonly Dictionary<ItemNames, Item> _itemsMap;
        private readonly CharacterCharacteristicCard _personalCCC;

        public Inventory(CharacterCharacteristicCard personalCCC)
        {
            _personalCCC = personalCCC;

            _itemsMap = new()
            {
                [ItemNames.AlienResources] = new AlienResource(),
                [ItemNames.ElectricResources] = new ElectricResource(),
                [ItemNames.MechanicalResources] = new MechanicalResource(),

                [ItemNames.SyneticMuscles] = new SyneticMuscles(),
                [ItemNames.Mutagens] = new Mutagens(),
                [ItemNames.ModifiedStemCells] = new ModifiedStemCells(),

                [ItemNames.Thermostat] = new Thermostat(),
                [ItemNames.ImprovedLaserBattery] = new ImprovedLaserBattery(),
                [ItemNames.ChargingChamberCapacitor] = new ChargingChamberCapacitor(),

                [ItemNames.LightCapacitor] = new LightCapacitor(),
                [ItemNames.ArmoredPads] = new ArmoredPads()
            };

            foreach (var key in _itemsMap.Keys)
            {
                _itemsMap[key].OnResourceAdded += ApplyEffect;
                _itemsMap[key].OnResourceTaked += ReverseEffect;
            }
        }
        public void AddItem(ItemNames dropName)
        {
            _itemsMap[dropName].amount += 1;
        }
        public void RemoveItem(ItemNames dropName, int count)
        {
            for (int i = 0; i < count; i++)
            {
                RemoveItem(dropName);
            }
        }
        public void RemoveItem(ItemNames dropName)
        {
            _itemsMap[dropName].amount -= 1;
        }

        private void ApplyEffect(Item item)
        {
            _itemsMap[item.Name].Effect(_personalCCC);
        }
        private void ReverseEffect(Item item)
        {
            _itemsMap[item.Name].ReverseEffect(_personalCCC);
        }

        public bool Contains(Dictionary<ItemNames, int> items)
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
        public bool Contains(ItemNames dropName, int count)
        {
            return _itemsMap.ContainsKey(dropName) && _itemsMap[dropName].amount >= count;
        }

        public Item GetItem(ItemNames name) => _itemsMap[name];
    }
}
