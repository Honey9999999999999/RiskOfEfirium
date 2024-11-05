using Architecture;
using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlueprintPlate : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _frame;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetBlueprint(Blueprint blueprint, UnityAction action)
    {
        ItemInfo info = Game.GetInteractor<InventorySystemInteractor>().ItemInformationCard.GetInfo(blueprint.ItemName);
        _frame.sprite = Game.GetInteractor<InventorySystemInteractor>().GetSpriteFrame(info.Tier);
        _icon.sprite = Resources.Load<Sprite>(info.IconPath);
        _text.text = info.Name;

        _button.onClick.AddListener(action);
    }
}
