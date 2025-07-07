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
                    { 1, "MapSystem/Prefabs/Rooms/GatewayRoom_D1" }
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
            [RoomType.RecreationRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/Room" }
                },
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RoomB" }
                }
            },
            [RoomType.CargoRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/CargoRoom_D4" }
                },
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/CargoRoom_D2" }
                }
            },
            [RoomType.LifeSupportRoom] = new()
            {
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RoomB" }
                }
            },
            [RoomType.CommandRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/Room" }
                }
            },
            [RoomType.SecurityRoom] = new()
            {
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RoomB" }
                }
            },
            [RoomType.Armory] = new()
            {
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/ArmoryRoom_D1" }
                }
            },
            [RoomType.EngineeringRoom] = new()
            {
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/EngineeringRoom_D1" }
                }
            },
            [RoomType.Restroom] = new()
            {
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RestRoom_D1" }
                }
            }
        };
    }
}
