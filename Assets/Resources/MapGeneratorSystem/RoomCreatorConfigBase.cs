using System.Collections.Generic;
using Assets.Scripts.Tools;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class RoomCreatorConfigBase
    {
        protected delegate Room RoomCreator<T>();
        protected readonly Dictionary<RoomType, ControlRandomList<RoomType>> _roomMap;
        protected readonly Dictionary<RoomType, ControlRandomList<RoomCreator<Room>>> _sizeMap;

        protected readonly Dictionary<RoomType, ControlRandomList<RoomType>> _roomNoOxMap;
        protected readonly Dictionary<RoomType, ControlRandomList<RoomCreator<Room>>> _sizeNoOxMap;

        protected readonly Dictionary<RoomType, ControlRandomList<RoomType>> _roomEndMap;
        protected readonly Dictionary<RoomType, ControlRandomList<RoomCreator<Room>>> _sizeEndMap;

        protected RoomCreatorConfigBase()
        {
            _roomMap = new();
            _sizeMap = new();

            _roomNoOxMap = new();
            _sizeNoOxMap = new();

            _roomEndMap = new();
            _sizeEndMap = new();
        }

        protected static Room CreateRoom<TType>() where TType : Room, new()
        {
            return new TType();
        }
        public Room CreateRandomRoomAt(Room parentRoom)
        {
            RoomType targetRoomType = isStartNoOxygenZone() ? _roomNoOxMap[parentRoom.type].GetValue() : _roomMap[parentRoom.type].GetValue();

            Room room = _sizeMap[targetRoomType].GetValue().Invoke();
            room.SetTypeRoom(targetRoomType);

            room.isEndNoOxygenZone = isEndNoOxygenZone();
            room.presenceOfOxygen = !(!room.isEndNoOxygenZone && (isStartNoOxygenZone() || !parentRoom.presenceOfOxygen));

            return room;

            bool isStartNoOxygenZone() => parentRoom.type == RoomType.LifeSupportRoom && !parentRoom.isEndNoOxygenZone;
            bool isEndNoOxygenZone() => targetRoomType == RoomType.LifeSupportRoom && !parentRoom.presenceOfOxygen;
        }
        public Room CreateRoom(RoomType roomType)
        {
            Room room = _sizeMap[roomType].GetValue().Invoke();
            room.SetTypeRoom(roomType);

            return room;
        }

        public Room CreateRandomEndRoomAt(Room parentRoom)
        {
            RoomType targetRoomType = _roomEndMap[parentRoom.type].GetValue();
            Room room = _sizeEndMap[targetRoomType].GetValue().Invoke();
            room.SetTypeRoom(targetRoomType);
            room.presenceOfOxygen = parentRoom.presenceOfOxygen;

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
