using System;
using System.Collections.Generic;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;

namespace Maps
{
    internal class RoomCreatorConfigExample : RoomCreatorConfigBase
    {
        protected override Dictionary<RoomType, Dictionary<Type, ControlRandomList<string>>> roomMap => new()
        {
            [RoomType.Gateway] = new()
            {
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RoomC" }
                }
            },
            [RoomType.ResidentialRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/Room" }
                },
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RoomB" }
                },
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RoomC" }
                }
            },
            [RoomType.CommandRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/Room" }
                }
            },
            [RoomType.Armory] = new()
            {
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/Armory" }
                }
            }
        };
    }
}
