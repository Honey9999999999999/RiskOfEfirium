using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class DropItemInfoSimple : DropItemsInfo
    {
        protected override Dictionary<ItemNames, string> _dropMap
        {
            get => new()
            {
                [ItemNames.MechanicalResources] = "Prefabs/DropItems/Gear",
                [ItemNames.ElectricResources] = "Prefabs/DropItems/ElBoard",
                [ItemNames.AlienResources] = "Prefabs/DropItems/DNA"
            };
        }
    }
}
