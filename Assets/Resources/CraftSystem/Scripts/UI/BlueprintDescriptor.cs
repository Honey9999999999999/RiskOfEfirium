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

        [SerializeField] private Transform _componentsTable;
        [SerializeField] private BlueprintComponent _componentBase;

        [SerializeField] private Button _button;

        public void OnEnable()
        {
            ItemCreator.OnCrafted += SetRequredComponents;
        }
        public void OnDisable()
        {
            ItemCreator.OnCrafted -= SetRequredComponents;
        }

        public void SetBlueprint()
        {
            Blueprint blueprint = WorkBenchWindow.currentBlueprint;
            ItemInfo info = blueprint.Info;

            _itemName.text = info.Name;
            _description.text = info.Description;

            SetRequredComponents();

            if (CheckAndSetActive(blueprint))
            {
                _button.onClick.RemoveAllListeners();
                SetAction(blueprint);
            }
        }

        public void Crear()
        {
            _itemName.text = "";
            _description.text = "";
            CrearTable();
            _button.interactable = false;
        }
        private void CrearTable()
        {
            for (int i = 0; i < _componentsTable.transform.childCount; i++)
            {
                Destroy(_componentsTable.transform.GetChild(i).gameObject);
            }
        }

        private void SetRequredComponents()
        {
            InventorySystemInteractor inventorySystem = Game.GetInteractor<InventorySystemInteractor>();
            Blueprint blueprint = WorkBenchWindow.currentBlueprint;

            CrearTable();

            foreach (ItemNames component in blueprint.Components.Keys)
            {
                ItemInfo info = inventorySystem.ItemInformationCard.GetInfo(component);
                Instantiate(_componentBase, _componentsTable).
                SetComponent(info, blueprint.Components[component], component);
            }
        }

        private void SetAction(Blueprint blueprint)
        {
            _button.onClick.AddListener
                (() =>
                    {
                        Game.GetInteractor<CraftSystemInteractor>().Crafter.Craft(blueprint);
                        CheckAndSetActive(blueprint);

                        _button.OnDeselect(null);
                    }
                );
        }

        private bool CheckAndSetActive(Blueprint blueprint)
        {
            _button.interactable = Game.GetInteractor<PlayerInteractor>()
                .Player.Inventory.Contains(blueprint.Components);

            return _button.interactable;
        }
    }
}
