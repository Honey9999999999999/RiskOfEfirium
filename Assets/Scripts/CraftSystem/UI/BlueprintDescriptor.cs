using Architecture;
using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CraftSystem
{
    public class BlueprintDescriptor : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _itemName;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Image _image;

        [SerializeField] private Transform _componentsTable;
        [SerializeField] private BlueprintComponent _componentBase;

        [SerializeField] private Button _button;

        public void SetBlueprint(Blueprint blueprint)
        {
            InventorySystemInteractor inventorySystem = Game.GetInteractor<InventorySystemInteractor>();
            ItemInfo info = inventorySystem.ItemInformationCard.GetInfo(blueprint.ItemName);

            _image.sprite = Resources.Load<Sprite>(info.IconPath);
            _itemName.text = info.Name;
            _description.text = info.Description;

            SetRequredComponents(blueprint);

            if (CheckAndSetActive(blueprint))
            {
                SetAction(blueprint);
            }
        }

        private void SetRequredComponents(Blueprint blueprint)
        {
            InventorySystemInteractor inventorySystem = Game.GetInteractor<InventorySystemInteractor>();

            for (int i = 0; i < _componentsTable.transform.childCount; i++)
            {
                Destroy(_componentsTable.transform.GetChild(i).gameObject);
            }

            foreach (NamesOfDrop component in blueprint.Components.Keys)
            {                
                ItemInfo info = inventorySystem.ItemInformationCard.GetInfo(component);
                Instantiate(_componentBase, _componentsTable).
                SetComponent(info, blueprint.Components[component]);
            }
        }

        private void SetAction(Blueprint blueprint)
        {
            _button.onClick.AddListener
                (() =>   
                    {
                        Game.GetInteractor<CraftSystemInteractor>().Crafter.Craft(blueprint);
                        CheckAndSetActive(blueprint);
                    }
                );
        }

        private bool CheckAndSetActive(Blueprint blueprint)
        {
            _button.interactable = Game.GetInteractor<InventorySystemInteractor>()
                .Inventory.Contains(blueprint.Components);

            return _button.interactable;
        }
    }
}
