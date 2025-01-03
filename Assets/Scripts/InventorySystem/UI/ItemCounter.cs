using Architecture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventorySystem
{
    public class ItemCounter : MonoBehaviour
    {
        [SerializeField] private Image _frame;
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _counter;

        public void SetInfo(ItemInfo info)
        {
            _frame.color = Game.GetInteractor<InventorySystemInteractor>().FrameColorMap[info.Tier];
            _icon.sprite = Resources.Load<Sprite>(info.IconPath);
        }

        public TextMeshProUGUI GetCounter() => _counter;
    }
}
