using Architecture;
using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounter : MonoBehaviour
{
    [SerializeField] private Image _frame;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _counter;

    [SerializeField] private InventoryColorMap _colorMap;

    [SerializeField] private bool AwakeOverride;
    [SerializeField] private ItemNames item;

    public void Awake()
    {
        if (AwakeOverride)
        {
            SetInfo(Game.GetInteractor<InventorySystemInteractor>().ItemInformationCard.GetInfo(item));
        }
    }

    public void SetInfo(ItemInfo info)
    {
        _frame.color = _colorMap.GetColorFor(info.Tier);
        _icon.sprite = Resources.Load<Sprite>(info.IconPath);
    }

    public TextMeshProUGUI GetCounter() => _counter;
}
