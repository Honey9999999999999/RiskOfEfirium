using Architecture;
using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BlueprintPlate : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private Sprite Zatichka;

    public void SetBlueprint(Blueprint blueprint, UnityAction action)
    {
        _icon.sprite = Zatichka;
        _text.text = Game.GetInteractor<InventorySystemInteractor>()
            .ItemInformationCard.GetInfo(blueprint.ItemName).Name;

        _button.onClick.AddListener(action);
    }
}
