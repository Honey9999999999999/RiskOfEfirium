using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class RoomLootConfigExample : RoomLootConfig
    {
        protected override Dictionary<RoomType, ControlRandomList<ItemNames>> LootMap => _lootMap;
        private readonly Dictionary<RoomType, ControlRandomList<ItemNames>> _lootMap = new()
        {
            [RoomType.ResidentialRoom] = new()
            {
                { 1, ItemNames.AlienResources },
                { 1, ItemNames.ElectricResources },
                { 1, ItemNames.MechanicalResources }
            }
        };
    }
}
