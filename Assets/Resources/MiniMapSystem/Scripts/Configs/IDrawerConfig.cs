using System;
using System.Collections.Generic;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Scripts.MiniMap.Configs
{
    public interface IDrawerConfig
    {
        public int textureBlockSize { get; }
        public int hallOffset { get; }
        public string minimapPath { get; }
        public string maskPath { get; }
        public string hallPath { get; }
        public string doorPath { get; }
        public string playerPath { get; }

        public Dictionary<Type, string> roomPrefabMap { get; }
        public Dictionary<RoomType, Color32> roomColorMap { get; }
    }
}
