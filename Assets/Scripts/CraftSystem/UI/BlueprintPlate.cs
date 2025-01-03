using Architecture;
using Assets.Scripts.InventorySystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlueprintPlate : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _frame;
    [SerializeField] private Image _icon;

    public void SetBlueprint(Blueprint blueprint, UnityAction action)
    {
        ItemInfo info = Game.GetInteractor<InventorySystemInteractor>().ItemInformationCard.GetInfo(blueprint.ItemName);
        _frame.sprite = Resources.Load<Sprite>("Sprites/CraftWindow/IconFrame");
        _icon.sprite = Resources.Load<Sprite>(info.IconPath);
        _frame.GetComponent<Image>().color = Game.GetInteractor<InventorySystemInteractor>().FrameColorMap[info.Tier];
        _button.GetComponent<Image>().color = Game.GetInteractor<InventorySystemInteractor>().FrameColorMap[info.Tier];

        _button.onClick.AddListener(action);
    }
}
