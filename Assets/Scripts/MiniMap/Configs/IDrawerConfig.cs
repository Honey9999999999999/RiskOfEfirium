using Assets.Scripts.LabyrinthGenerator;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.MiniMap.Configs
{
    public interface IDrawerConfig
    {
        public int textureBlockSize { get; }
        public int hallOffset { get; }
        public string minimapPath { get; }
        public string hallPath { get; }
        public string doorPath { get; }
        public string playerPath { get; }

        public Dictionary<Type, string> roomPrefabMap { get; }
        public Dictionary<RoomType, Color32> roomColorMap { get; }
    }
}
