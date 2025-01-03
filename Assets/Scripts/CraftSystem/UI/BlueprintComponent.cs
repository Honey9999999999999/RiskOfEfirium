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

        public void SetComponent(ItemInfo info, int count, NamesOfDrop name)
        {
            _frame.color = Game.GetInteractor<InventorySystemInteractor>().FrameColorMap[info.Tier];
            _icon.sprite = Resources.Load<Sprite>(info.IconPath);
            _counter.text = count.ToString();

            if (Game.GetInteractor<InventorySystemInteractor>().PlayerInventory.Contains(name, count))
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
