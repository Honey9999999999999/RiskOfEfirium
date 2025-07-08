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
                    { 1, "MapSystem/Prefabs/Rooms/ResidentalRoom_D4" }
                },
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/ResidentalRoom_D2" }
                },
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/ResidentalRoom_D1" }
                }
            },
            [RoomType.RecreationRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RecreationRoom_D4" }
                },
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "MapSystem/Prefabs/Rooms/RecreationRoom_D2" }
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
                    { 1, "MapSystem/Prefabs/Rooms/LifeSupportRoom_D2" }
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
                    { 1, "MapSystem/Prefabs/Rooms/SecurityRoom_D2" }
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
