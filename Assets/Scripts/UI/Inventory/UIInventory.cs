using Assets.Scripts.InventorySystem;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.Inventory
{
    public class UIInventory : MonoBehaviour
    {
        public TextMeshProUGUI alienCounter;
        public TextMeshProUGUI ElectricalCounter;
        public TextMeshProUGUI MechanicalCounter;

        public void ChangeCountValue(Resource resource)
        {
            switch (resource.Name)
            {
                case NamesOfDrop.MechanicalResources:
                    MechanicalCounter.text = resource.amount.ToString();
                    break;
                case NamesOfDrop.ElectricResources:
                    ElectricalCounter.text = resource.amount.ToString();
                    break;
                case NamesOfDrop.AlienResources:
                    alienCounter.text = resource.amount.ToString();
                    break;
                default:
                    throw new System.Exception($"This {resource.Name} is not a resource");
            }
        }
    }
}
