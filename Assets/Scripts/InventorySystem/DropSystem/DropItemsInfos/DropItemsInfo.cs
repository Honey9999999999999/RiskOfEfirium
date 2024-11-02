using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class DropItemsInfo
    {
        public abstract Dictionary<NamesOfDrop, string> _dropMap { get; }
    }
}
