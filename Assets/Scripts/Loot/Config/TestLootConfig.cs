using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.Loot.Config
{
    public class TestLootConfig : RoomLootConfig
    {
        protected override Dictionary<RoomType, ControlRandomList<NamesOfDrop>> LootMap => _lootMap;
        private readonly Dictionary<RoomType, ControlRandomList<NamesOfDrop>> _lootMap = new()
        {
            [RoomType.ResidentialRoom] = new()
            {
                { 1, NamesOfDrop.AlienResources },
                { 1, NamesOfDrop.ElectricResources },
                { 1, NamesOfDrop.MechanicalResources }
            }            
        };
    }
}
