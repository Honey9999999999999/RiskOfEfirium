using Assets.Scripts.InventorySystem;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Inventory
{
    public class UIInventory : MonoBehaviour
    {
        private readonly Dictionary<Type, TextMeshProUGUI> _countersMap = new();
        private const string PATH_TO_COUNTER_PREFAB = "Prefabs/UI/Resource";

        public void ChangeCountValue(Item item)
        {
            if (!_countersMap.ContainsKey(item.GetType()))
            {
                AddCounter(item.GetType());
            }

            if(item.amount <= 0)
            {
                Destroy(_countersMap[item.GetType()].transform.parent.gameObject);
                _countersMap.Remove(item.GetType());
            }
            else
            {
                _countersMap[item.GetType()].text = item.amount.ToString();
            }
        }

        private void AddCounter(Type dropName)
        {
            Image image = ResourceLoader.Load<Image>(PATH_TO_COUNTER_PREFAB, transform);
            image.sprite = ResourceLoader.Load<Sprite>("Sprites/MiniMap/Minimaze/SimpleRoomA");
            _countersMap[dropName] = image.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        }
    }
}
