using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class MapGeneratorConfig
    {
        protected Random random;
        protected List<Room> rooms;

        protected readonly RoomCreatorConfigBase roomCreatorConfig;

        protected MapGeneratorConfig(RoomCreatorConfigBase roomCreatorConfig)
        {
            random = new Random();
            this.roomCreatorConfig = roomCreatorConfig;
        }

        public abstract int roomsCount { get; }

        public abstract List<Room> CreateLevelMap();

        protected Door GetRandomFreeDoor()
        {
            List<Door> freeDoors = GetFreeDoors();

            return freeDoors[random.Next(freeDoors.Count)];
        }

        protected List<Door> GetFreeDoors()
        {
            List<Door> freeDoors = new();

            foreach (var room in rooms)
            {
                foreach (var block in room.blocks)
                {
                    foreach (var door in block.doors)
                    {
                        if (!door.IsLeadSomeWhere)
                        {
                            freeDoors.Add(door);
                        }
                    }
                }
            }

            return freeDoors;
        }

        protected List<Door> GetAllMatchingDoorsFromRoom(Door targetDoor, Room room)
        {
            List<Door> matchingDoors = new();
            IntVector2 direction = -targetDoor.Direction;

            foreach (var block in room.blocks)
            {
                foreach (var door in block.doors)
                {
                    if (door.Direction == direction)
                    {
                        matchingDoors.Add(door);
                    }
                }
            }

            return matchingDoors;
        }

        protected bool IsFitRoom(List<IntVector2> occupiedPositions)
        {
            foreach (var position in occupiedPositions)
            {
                foreach (var room in rooms)
                {
                    foreach (var block in room.blocks)
                    {
                        if (block.position == position)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public Room GetRoom(IntVector2 position)
        {
            if (FindRoom(position, out Room room))
            {
                return room;
            }

            throw new Exception("This room does not exist");
        }
        public bool FindRoom(IntVector2 position, out Room room)
        {
            foreach (var r in rooms)
            {
                if (r.TryGetBlock(position, out _))
                {
                    room = r;
                    return true;
                }
            }

            room = null;
            return false;
        }
    }
}
