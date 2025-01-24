using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class MapGeneratorConfigSimple : MapGeneratorConfig
    {
        public const int MAX_ROOMS = 30;

        public MapGeneratorConfigSimple(RoomCreatorConfigBase mainRoomCreatorConfig) : base(mainRoomCreatorConfig)
        {
        }

        public override int roomsCount => MAX_ROOMS;

        public override List<Room> CreateLevelMap()
        {
            InitializeMap();
            AddMainRooms();
            AddRequredRooms();
            AddCloseRooms();

            return rooms;
        }

        private bool TryPasteRoomInDoor(Door freeDoor, Room room)
        {
            room.RandomRotate();
            room.SetInPosition(freeDoor.TargetPosition);

            for (int i = 0; i < 4; i++)
            {
                List<Door> matchingDoors = GetAllMatchingDoorsFromRoom(freeDoor, room);

                while (matchingDoors.Count > 0)
                {
                    Door chekingDoor = matchingDoors[random.Next(matchingDoors.Count)];
                    room.OverrideCenter(room.GetBlock(chekingDoor.SelfPosition));

                    if (IsFitRoom(room.GetOccupiedPosition()))
                    {
                        rooms.Add(room);
                        freeDoor.IsLeadSomeWhere = true;
                        freeDoor.TargetRoom = room;

                        chekingDoor.IsLeadSomeWhere = true;
                        chekingDoor.TargetRoom = GetRoom(freeDoor.SelfPosition);

                        return true;
                    }
                    else
                    {
                        matchingDoors.Remove(chekingDoor);
                    }
                }

                if (matchingDoors.Count <= 0)
                {
                    if (i < 3)
                    {
                        room.Rotate();
                    }
                }
                else
                {
                    break;
                }
            }

            return false;
        }

        private void InitializeMap()
        {
            rooms = new List<Room>()
            {
                new SimpleRoomC()
            };
            rooms[0].RandomRotate();
            rooms[0].SetTypeRoom(RoomType.Gateway);
        }

        private void AddMainRooms()
        {
            while (rooms.Count < MAX_ROOMS)
            {
                Door freeDoor = GetRandomFreeDoor();
                TryPasteRoomInDoor(freeDoor, roomCreatorConfig.CreateRandomRoomAt(freeDoor.ParentRoom));
            }
        }

        private void AddRequredRooms()
        {
            Dictionary<RoomType, bool> isRoomAddedMap = new()
            {
                [RoomType.CommandRoom] = false
            };

            foreach (var room in rooms)
            {
                isRoomAddedMap[room.type] = true;
            }

            foreach (var key in isRoomAddedMap.Keys.ToArray())
            {
                while (!isRoomAddedMap[key])
                {
                    Door freeDoor = GetRandomFreeDoor();

                    isRoomAddedMap[key] = TryPasteRoomInDoor(freeDoor, roomCreatorConfig.CreateRoom(key));
                }
            }
        }

        private void AddCloseRooms()
        {
            List<Door> freeDoors = GetFreeDoors();

            foreach (var freeDoor in freeDoors)
            {
                TryPasteRoomInDoor(freeDoor, roomCreatorConfig.CreateRandomEndRoomAt(freeDoor.ParentRoom));
            }
        }
    }
}
