using Assets.Scripts.Tools;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class RoomCreatorConfigBase
    {
        protected delegate Room RoomCreator<T>();
        protected readonly Dictionary<RoomType, ControlRandomList<RoomType>> _roomMap;
        protected readonly Dictionary<RoomType, ControlRandomList<RoomCreator<Room>>> _sizeMap;

        protected RoomCreatorConfigBase()
        {
            _sizeMap = new();
        }

        protected static Room CreateRoom<TType>() where TType : Room, new()
        {
            return new TType();
        }
        public Room CreateRandomRoomAt(RoomType roomType)
        {
            return _sizeMap[_roomMap[roomType].GetValue()].Invoke();
        }
    }
}
