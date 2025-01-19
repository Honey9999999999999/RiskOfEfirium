using System;
using System.Collections.Generic;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Tools;
using UnityEngine;

namespace Maps
{
    internal abstract class RoomCreatorConfigBase
    {
        protected abstract Dictionary<RoomType, Dictionary<Type, ControlRandomList<string>>> roomMap { get; }

        public GameObject GetRoom(RoomType type, Type room)
        {
            return ResourceLoader.Load<GameObject>(roomMap[type][room].GetValue());
        }
    }
}
