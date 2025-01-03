using Architecture;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.InventorySystem
{
    public class UIInventory : MonoBehaviour
    {
        private readonly Dictionary<Type, TextMeshProUGUI> _countersMap = new();
        private const string PATH_TO_COUNTER_PREFAB = "Prefabs/InventorySystem/ItemCounter";

        public void ChangeCountValue(Item item)
        {
            if (!_countersMap.ContainsKey(item.GetType()))
            {
                AddCounter(item);
            }

            if (item.amount <= 0)
            {
                Destroy(_countersMap[item.GetType()].transform.parent.gameObject);
                _countersMap.Remove(item.GetType());
            }
            else
            {
                _countersMap[item.GetType()].text = item.amount.ToString();
            }
        }

        private void AddCounter(Item item)
        {
            ItemInfo info = Game.GetInteractor<InventorySystemInteractor>().ItemInformationCard.GetInfo(item.Name);
            ItemCounter itemCounter = ResourceLoader.Load<ItemCounter>(PATH_TO_COUNTER_PREFAB, transform);
            itemCounter.SetInfo(info);
            _countersMap[item.GetType()] = itemCounter.GetCounter();
        }
    }
}
