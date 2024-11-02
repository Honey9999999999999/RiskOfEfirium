using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class DropItemInfoSimple : DropItemsInfo
    {
        protected override Dictionary<NamesOfDrop, string> _dropMap
        {
            get => new()
            {
                [NamesOfDrop.MechanicalResources] = "Prefabs/DropItems/Gear",
                [NamesOfDrop.ElectricResources] = "Prefabs/DropItems/ElBoard",
                [NamesOfDrop.AlienResources] = "Prefabs/DropItems/DNA"
            };
        }
    }
}
