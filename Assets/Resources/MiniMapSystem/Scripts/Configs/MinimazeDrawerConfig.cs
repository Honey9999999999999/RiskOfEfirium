using System;
using System.Collections.Generic;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Scripts.MiniMap.Configs
{
    public class MinimazeDrawerConfig : IDrawerConfig
    {
        public int textureBlockSize => 64;
        public int hallOffset => -10;

        public string minimapPath => "MiniMapSystem/Prefabs/Minimaze/Minimap";
        public string maskPath => "Prefabs/MiniMap/Masks/CubeMask";

        public string hallPath => "MiniMapSystem/Prefabs/Minimaze/Hall";

        public string doorPath => "MiniMapSystem/Prefabs/Minimaze/Door";

        public string playerPath => "MiniMapSystem/Prefabs/Minimaze/Player";

        public Dictionary<Type, string> roomPrefabMap => new()
        {
            [typeof(SimpleRoomA)] = "MiniMapSystem/Prefabs/Minimaze/SimpleRoomA",
            [typeof(SimpleRoomB)] = "MiniMapSystem/Prefabs/Minimaze/SimpleRoomB",
            [typeof(SimpleRoomC)] = "MiniMapSystem/Prefabs/Minimaze/SimpleRoomC",

            [typeof(LongRoomA)] = "MiniMapSystem/Prefabs/Minimaze/LongRoomA",
            [typeof(LongRoomB)] = "MiniMapSystem/Prefabs/Minimaze/LongRoomB",
            [typeof(LongRoomC)] = "MiniMapSystem/Prefabs/Minimaze/LongRoomC",

            [typeof(MediumRoom)] = "MiniMapSystem/Prefabs/Minimaze/MediumRoom",
            [typeof(BigRoom)] = "MiniMapSystem/Prefabs/Minimaze/BigRoom",
        };

        public Dictionary<RoomType, Color32> roomColorMap => new()
        {
            [RoomType.Arboretum] = new Color32(60, 120, 30, 255),
            [RoomType.Gateway] = new Color32(240, 220, 130, 255),
            [RoomType.LifeSupportRoom] = new Color32(25, 235, 175, 255),
            [RoomType.Armory] = new Color32(200, 0, 0, 255),
            [RoomType.Bathroom] = new Color32(255, 255, 255, 255),
            [RoomType.CargoRoom] = new Color32(170, 110, 60, 255),
            [RoomType.CommandRoom] = new Color32(140, 10, 10, 255),
            [RoomType.Diner] = new Color32(190, 80, 140, 255),
            [RoomType.EngineeringRoom] = new Color32(230, 235, 15, 255),
            [RoomType.HibernationRoom] = new Color32(0, 255, 250, 255),
            [RoomType.Laboratory] = new Color32(160, 10, 190, 255),
            [RoomType.MedicalRoom] = new Color32(0, 200, 0, 255),
            [RoomType.RecreationRoom] = new Color32(255, 120, 0, 255),
            [RoomType.ResidentialRoom] = new Color32(190, 255, 50, 255),
            [RoomType.Restroom] = new Color32(150, 150, 150, 255),
            [RoomType.SecretRoom] = new Color32(255, 255, 255, 255),
            [RoomType.SecurityRoom] = new Color32(0, 0, 255, 255),
            [RoomType.UnTyped] = new Color32(255, 255, 255, 255)
        };
    }
}
