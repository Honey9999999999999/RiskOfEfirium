using Assets.Scripts.InventorySystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlueprintPlate : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _frame;
    [SerializeField] private Image _icon;

    [SerializeField] private InventoryColorMap colorMap;

    public void SetBlueprint(Blueprint blueprint, UnityAction action)
    {
        ItemInfo info = blueprint.Info;
        _icon.sprite = Resources.Load<Sprite>(info.IconPath);
        _frame.GetComponent<Image>().color = colorMap.GetColorFor(info.Tier);
        _button.GetComponent<Image>().color = colorMap.GetColorFor(info.Tier);

        _button.onClick.AddListener(action);
    }
}
