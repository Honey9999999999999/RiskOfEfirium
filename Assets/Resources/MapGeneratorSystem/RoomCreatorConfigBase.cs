using System.Collections.Generic;
using Assets.Scripts.Tools;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class RoomCreatorConfigBase
    {
        protected delegate Room RoomCreator<T>();
        protected readonly Dictionary<RoomType, ControlRandomList<RoomType>> _roomMap;
        protected readonly Dictionary<RoomType, ControlRandomList<RoomCreator<Room>>> _sizeMap;

        protected readonly Dictionary<RoomType, ControlRandomList<RoomType>> _roomEndMap;
        protected readonly Dictionary<RoomType, ControlRandomList<RoomCreator<Room>>> _sizeEndMap;

        protected RoomCreatorConfigBase()
        {
            _roomMap = new();
            _sizeMap = new();
            _roomEndMap = new();
            _sizeEndMap = new();
        }

        protected static Room CreateRoom<TType>() where TType : Room, new()
        {
            return new TType();
        }
        public Room CreateRandomRoomAt(RoomType roomType)
        {
            RoomType targetRoomType = _roomMap[roomType].GetValue();
            Room room = _sizeMap[targetRoomType].GetValue().Invoke();
            room.SetTypeRoom(targetRoomType);

            return room;
        }
        public Room CreateRoom(RoomType roomType)
        {
            Room room = _sizeMap[roomType].GetValue().Invoke();
            room.SetTypeRoom(roomType);

            return room;
        }

        public Room CreateRandomEndRoomAt(RoomType roomType)
        {
            RoomType targetRoomType = _roomEndMap[roomType].GetValue();
            Room room = _sizeEndMap[targetRoomType].GetValue().Invoke();
            room.SetTypeRoom(targetRoomType);

            return room;
        }
        public Room CreateEndRoom(RoomType roomType)
        {
            Room room = _sizeEndMap[roomType].GetValue().Invoke();
            room.SetTypeRoom(roomType);

            return room;
        }
    }
}
