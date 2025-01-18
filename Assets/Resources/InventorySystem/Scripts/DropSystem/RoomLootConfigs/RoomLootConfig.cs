using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class RoomLootConfig
    {
        protected abstract Dictionary<RoomType, ControlRandomList<ItemNames>> LootMap { get; }

        public ItemNames GetSpawnItem(RoomType type)
        {
            return LootMap[type].GetValue();
        }
    }
}
