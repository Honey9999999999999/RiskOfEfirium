using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.MiniMap.Configs
{
    public class MinimazeDrawerConfig : IDrawerConfig
    {
        public int textureBlockSize => 64;
        public int hallOffset => -10;

        public string minimapPath => "Prefabs/MiniMap/Minimaze/Minimap";

        public string hallPath => "Prefabs/MiniMap/Minimaze/Hall";

        public string doorPath => "Prefabs/MiniMap/Minimaze/Door";

        public string playerPath => "Prefabs/MiniMap/Minimaze/Player";

        public Dictionary<Type, string> roomPrefabMap => new()
        {
            [typeof(SimpleRoomA)] = "Prefabs/MiniMap/Minimaze/SimpleRoomA",
            [typeof(SimpleRoomB)] = "Prefabs/MiniMap/Minimaze/SimpleRoomB",
            [typeof(SimpleRoomC)] = "Prefabs/MiniMap/Minimaze/SimpleRoomC",

            [typeof(LongRoomA)] = "Prefabs/MiniMap/Minimaze/LongRoomA",
            [typeof(LongRoomB)] = "Prefabs/MiniMap/Minimaze/LongRoomB",
            [typeof(LongRoomC)] = "Prefabs/MiniMap/Minimaze/LongRoomC",

            [typeof(MediumRoom)] = "Prefabs/MiniMap/Minimaze/MediumRoom",
            [typeof(BigRoom)] = "Prefabs/MiniMap/Minimaze/BigRoom",
        };

        public Dictionary<RoomType, Color32> roomColorMap => new()
        {
            [RoomType.Armory] = new Color32(255, 255, 255, 255),
            [RoomType.Bathroom] = new Color32(255, 255, 255, 255),
            [RoomType.CargoRoom] = new Color32(255, 255, 255, 255),
            [RoomType.CommandRoom] = new Color32(255, 255, 255, 255),
            [RoomType.Diner] = new Color32(255, 255, 255, 255),
            [RoomType.EngineeringRoom] = new Color32(255, 255, 255, 255),
            [RoomType.HibernationRoom] = new Color32(255, 255, 255, 255),
            [RoomType.Laboratory] = new Color32(255, 255, 255, 255),
            [RoomType.MedicalRoom] = new Color32(255, 255, 255, 255),
            [RoomType.RecreationRoom] = new Color32(255, 255, 255, 255),
            [RoomType.ResidentialRoom] = new Color32(255, 255, 255, 255),
            [RoomType.Restroom] = new Color32(255, 255, 255, 255),
            [RoomType.SecretRoom] = new Color32(255, 255, 255, 255),
            [RoomType.SecurityRoom] = new Color32(255, 255, 255, 255),
            [RoomType.UnTyped] = new Color32(255, 255, 255, 255)
        };
    }
}
