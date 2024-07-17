using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem.DropSystem.DropItemsInfos
{
    public class DropItemInfoSimple : DropItemsInfo
    {
        public override Dictionary<NamesOfDrop, string> _dropMap { get => new() 
        {
            [NamesOfDrop.MechanicalResources] = "",
            [NamesOfDrop.ElectricResources] = "",
            [NamesOfDrop.AlienResources] = "Prefabs/DropItems/TestDrop"
        }; }
    }
}
