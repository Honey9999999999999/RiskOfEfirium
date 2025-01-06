using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class DropItemsInfo
    {
        protected abstract Dictionary<ItemNames, string> _dropMap { get; }

        public string GetPathToDrop(ItemNames nameOfDrop)
        {
            return _dropMap[nameOfDrop];
        }
    }
}
