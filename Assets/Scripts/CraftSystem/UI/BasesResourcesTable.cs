using Architecture;
using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.CraftSystem.UI
{
    public class BasesResourcesTable : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI mechanicalCounter;
        [SerializeField] TextMeshProUGUI electricalCounter;
        [SerializeField] TextMeshProUGUI alienCounter;

        public void OnEnable()
        {
            ItemCreator.OnCrafted += UpdateCounters;
        }
        public void OnDisable()
        {
            ItemCreator.OnCrafted -= UpdateCounters;

        }

        public void OpenTable()
        {
            gameObject.SetActive(true);
            UpdateCounters();
        }

        private void UpdateCounters()
        {
            Inventory inventory = Game.GetInteractor<InventorySystemInteractor>().PlayerInventory;
            mechanicalCounter.text = inventory.GetItem(NamesOfDrop.MechanicalResources).amount.ToString();
            electricalCounter.text = inventory.GetItem(NamesOfDrop.ElectricResources).amount.ToString();
            alienCounter.text = inventory.GetItem(NamesOfDrop.AlienResources).amount.ToString();
        }

        public void CloseTable()
        {
            gameObject.SetActive(false);
        }
    }
}
