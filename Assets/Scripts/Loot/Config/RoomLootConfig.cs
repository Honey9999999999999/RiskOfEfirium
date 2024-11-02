using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.Loot
{
    public abstract class RoomLootConfig
    {
        protected abstract Dictionary<RoomType, ControlRandomList<NamesOfDrop>> LootMap { get; }

        public NamesOfDrop GetSpawnItem(RoomType type)
        {
            return LootMap[type].GetValue();
        }
    }
}
