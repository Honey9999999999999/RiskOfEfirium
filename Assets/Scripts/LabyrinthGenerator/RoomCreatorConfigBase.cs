using Assets.Scripts.Tools;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class RoomCreatorConfigBase
    {
        protected delegate Room RoomCreator<T>();
        protected readonly ControlRandomList<RoomCreator<Room>> _chanceMap;

        protected RoomCreatorConfigBase()
        {
            _chanceMap = new();
        }

        protected static Room CreateRoom<TType>() where TType : Room, new()
        {
            return new TType();
        }
        public Room CreateRandomRoom()
        {
            return _chanceMap.GetValue().Invoke();
        }
    }
}
