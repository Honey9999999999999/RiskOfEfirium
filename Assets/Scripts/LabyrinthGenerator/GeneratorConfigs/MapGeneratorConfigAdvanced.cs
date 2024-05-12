using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class MapGeneratorConfigAdvanced : MapGeneratorConfig
    {
        public const int MAX_ROOMS = 300;
        public override int roomsCount => MAX_ROOMS;

        public override List<Room> CreateLevelMap()
        {
            rooms = new List<Room>()
            {
                new TRoom()
            };
            rooms[0].RandomRotate();

            while (rooms.Count < MAX_ROOMS)
            {
                Door freeDoor = GetRandomFreeDoor();
                Room room = new TRoom();
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
                            break;
                        }
                        else
                        {
                            matchingDoors.Remove(chekingDoor);
                        }
                    }

                    if(matchingDoors.Count <= 0)
                    {
                        if(i < 3)
                        {
                            room.RandomRotate();
                        }                        
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return rooms;
        }

        
        private Door GetRandomFreeDoor()
        {
            List<Door> freeDoors = GetFreeDoors();

            return freeDoors[random.Next(freeDoors.Count)];
        }

        private List<Door> GetFreeDoors()
        {
            List<Door> freeDoors = new();

            foreach (var room in rooms)
            {
                foreach (var block in room.blocks)
                {
                    foreach (var door in block.doors)
                    {
                        if (!door.isLeadSomeWhere)
                        {
                            freeDoors.Add(door);
                        }
                    }
                }
            }

            return freeDoors;
        }

        private List<Door> GetAllMatchingDoorsFromRoom(Door targetDoor, Room room)
        {
            List<Door> matchingDoors = new();
            IntVector2 direction = -targetDoor.direction;

            foreach (var block in room.blocks)
            {
                foreach (var door in block.doors)
                {
                    if(door.direction == direction)
                    {
                        matchingDoors.Add(door);
                    }
                }
            }

            return matchingDoors;
        }

        private bool IsFitRoom(List<IntVector2> occupiedPositions)
        {
            foreach (var position in occupiedPositions)
            {
                foreach (var room in rooms)
                {
                    foreach (var block in room.blocks)
                    {
                        if(block.position == position)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
    }
}
