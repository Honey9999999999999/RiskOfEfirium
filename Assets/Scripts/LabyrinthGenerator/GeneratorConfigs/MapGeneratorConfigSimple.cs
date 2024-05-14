using Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class MapGeneratorConfigSimple : MapGeneratorConfig
    {
        public const int MAX_ROOMS = 30;

        public MapGeneratorConfigSimple(RoomCreatorConfigBase roomCreatorConfig) : base(roomCreatorConfig)
        {
        }

        public override int roomsCount => MAX_ROOMS;

        public override List<Room> CreateLevelMap()
        {
            rooms = new List<Room>()
            {
                new SimpleRoomA()
            };
            rooms[0].RandomRotate();

            while (rooms.Count < MAX_ROOMS)
            {
                CreateRoom(roomCreatorConfig.CreateRandomRoom());
            }            

            AddCloseRooms();

            foreach (var room in rooms)
            {
                room.DefineRoomType();
            }

            return rooms;
        }

        private void CreateRoom(Room room)
        {
            Door freeDoor = GetRandomFreeDoor();
            CreateRoomInDoor(freeDoor, room);
        }
        private void CreateRoomInDoor(Door freeDoor, Room room)
        {
            room.RandomRotate();
            room.SetInPosition(freeDoor.targetPosition);

            for (int i = 0; i < 4; i++)
            {
                List<Door> matchingDoors = GetAllMatchingDoorsFromRoom(freeDoor, room);

                while (matchingDoors.Count > 0)
                {
                    Door chekingDoor = matchingDoors[random.Next(matchingDoors.Count)];
                    room.OverrideCenter(room.GetBlock(chekingDoor.selfPosition));

                    if (IsFitRoom(room.GetOccupiedPosition()))
                    {
                        rooms.Add(room);
                        freeDoor.isLeadSomeWhere = true;
                        freeDoor.targetRoom = room;

                        chekingDoor.isLeadSomeWhere = true;
                        chekingDoor.targetRoom = GetRoom(freeDoor.selfPosition);

                        break;
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
        }

        private void AddCloseRooms()
        {
            List<Door> freeDoors = GetFreeDoors();

            foreach (var door in freeDoors)
            {
                CreateRoomInDoor(door, random.Next(0, 2) == 1 ? new SimpleRoomC() : new LongRoomC());
                //rooms[rooms.Count - 1].DefineRoomType();
            }
        }       
    }
}
