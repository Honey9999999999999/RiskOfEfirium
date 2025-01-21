using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class DropItemInfoSimple : DropItemsInfo
    {
        protected override Dictionary<ItemNames, string> _dropMap
        {
            get => new()
            {
                [ItemNames.MechanicalResources] = "InventorySystem/Prefabs/DropItems/Gear",
                [ItemNames.ElectricResources] = "InventorySystem/Prefabs/DropItems/ElBoard",
                [ItemNames.AlienResources] = "InventorySystem/Prefabs/DropItems/DNA"
            };
        }
    }
}
