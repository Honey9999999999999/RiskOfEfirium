using Architecture;
using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CraftSystem
{
    [RequireComponent(typeof(Image))]
    public class BlueprintComponent : MonoBehaviour
    {
        [SerializeField] private Image _frame;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _counter;

        [SerializeField] private InventoryColorMap _colorMap;

        public void SetComponent(ItemInfo info, int count, ItemNames name)
        {
            _frame.color = _colorMap.GetColorFor(info.Tier);
            _icon.sprite = Resources.Load<Sprite>(info.IconPath);
            _counter.text = count.ToString();

            if (Game.GetInteractor<PlayerInteractor>().Player.Inventory.Contains(name, count))
            {
                _counter.color = Color.white;
            }
            else
            {
                _counter.color = Color.red;
            }
        }
    }
}
