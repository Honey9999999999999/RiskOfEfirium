using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class DropItemInfoSimple : DropItemsInfo
    {
        public override Dictionary<NamesOfDrop, string> _dropMap
        {
            get => new()
            {
                [NamesOfDrop.MechanicalResources] = "Prefabs/DropItems/TestDrop",
                [NamesOfDrop.ElectricResources] = "Prefabs/DropItems/TestDrop",
                [NamesOfDrop.AlienResources] = "Prefabs/DropItems/TestDrop"
            };
        }
    }
}
