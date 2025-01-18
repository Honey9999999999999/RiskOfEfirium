using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;

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
                    { 1, "Prefabs/Rooms/RoomC" }
                }
            },
            [RoomType.ResidentialRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "Prefabs/Rooms/Room" }
                },
                [typeof(SimpleRoomB)] = new()
                {
                    { 1, "Prefabs/Rooms/RoomB" }
                },
                [typeof(SimpleRoomC)] = new()
                {
                    { 1, "Prefabs/Rooms/RoomC" }
                }
            },
            [RoomType.CommandRoom] = new()
            {
                [typeof(SimpleRoomA)] = new()
                {
                    { 1, "Prefabs/Rooms/Room" }
                }
            }
        };
    }
}
