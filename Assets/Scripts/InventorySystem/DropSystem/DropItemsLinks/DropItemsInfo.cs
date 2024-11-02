using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class DropItemsInfo
    {
        protected abstract Dictionary<NamesOfDrop, string> _dropMap { get; }

        public string GetPathToDrop(NamesOfDrop nameOfDrop)
        {
            return _dropMap[nameOfDrop];
        }
    }
}
