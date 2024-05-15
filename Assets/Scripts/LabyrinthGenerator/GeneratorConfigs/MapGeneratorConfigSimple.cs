using Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class MapGeneratorConfigSimple : MapGeneratorConfig
    {
        public const int MAX_ROOMS = 10;        

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
                CreateRoom(roomCreatorConfig.CreateRandomRoomAt(RoomType.CargoRoom));
            }

            foreach (var room in rooms)
            {
                room.DefineRoomType();
            }

            CreateRequestRooms();

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

        private void CreateRequestRooms()
        {
            Dictionary<RoomType, bool> roomCheckMap = new()
            {
                [RoomType.Armory] = false,
                [RoomType.Laboratory] = false,
                [RoomType.EngineeringRoom] = false
            };

            Dictionary<RoomType, RoomType> roomMap = new()
            {
                [RoomType.Armory] = RoomType.SecurityRoom,
                [RoomType.Laboratory] = RoomType.MedicalRoom,
                [RoomType.EngineeringRoom] = RoomType.SecurityRoom
            };

            List<Door> usedDoors = new();

            foreach (var room in rooms)
            {
                roomCheckMap[room.type] = true;
            }

            foreach (var type in roomCheckMap.Keys.ToArray())
            {
                while (!roomCheckMap[type])
                {
                    Door door = GetRandomFreeDoor();

                    if(!usedDoors.Contains(door))
                    {
                        List<IntVector2> ocupPos = new()
                        {
                            new(0, 0),
                            door.direction
                        };

                        for (int i = 0; i < ocupPos.Count; i++)
                        {
                            ocupPos[i] += door.targetPosition;
                        }

                        if (IsFitRoom(ocupPos))
                        {
                            CreateRoomInDoor(door, new SimpleRoomB());
                            Room room = GetRoom(door.targetPosition);
                            room.SetTypeRoom(roomMap[type]);
                            usedDoors.Add(door);

                            room.TryGetFreeDoor(out door);
                            CreateRoomInDoor(door, new SimpleRoomC());
                            room = GetRoom(door.targetPosition);
                            room.SetTypeRoom(type);

                            roomCheckMap[type] = true;
                        }
                    }
                }
            }
        }

        private void AddCloseRooms()
        {
            List<Door> freeDoors = GetFreeDoors();

            foreach (var door in freeDoors)
            {
                Room room = GetRoom(door.selfPosition);

                if(room.type == RoomType.MedicalRoom || room.type == RoomType.SecurityRoom)
                {
                    CreateRoomInDoor(door, new SimpleRoomC());
                }
                else
                {
                    CreateRoomInDoor(door, random.Next(0, 2) == 1 ? new SimpleRoomC() : new LongRoomC());
                }
                
                //rooms[rooms.Count - 1].DefineRoomType();
            }
        }       
    }
}
