using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class MapGeneratorConfig
    {
        protected Random random;
        protected List<Room> rooms;

        protected MapGeneratorConfig()
        {
            random = new Random();
        }

        public abstract int roomsCount { get; }
        public abstract List<Room> CreateLevelMap();

        protected Room GetRoom()
        {
            if(rooms.Count <= 0)
            {
                throw new Exception("List<Room> has't rooms!!");
            }

            Room room;
            bool isChoosed = false;

            do
            {
                room = rooms[random.Next(rooms.Count)];

                int numberFreePasses = room.GetFreePasses().Count;
                int numberBusyPasses = room.GetBusyPasses().Count;

                if (numberBusyPasses < room.maxCountPasses && numberFreePasses > random.Next(room.maxCountPasses))
                {
                    isChoosed = true;
                }
            }
            while (!isChoosed);

            return room;
        }

        protected bool IsFitsRoom(List<Position> occupidePlases)
        {
            foreach (var pos in occupidePlases)
            {
                if (IsSomeOneClaims(pos))
                {
                    return false;
                }
            }

            return true;
        }
        protected bool IsSomeOneClaims(Position selectedPosition)
        {
            foreach (var room in rooms)
            {
                foreach (var pos in room.occupiedPlaces)
                {
                    if (pos.Equals(selectedPosition))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected void LinkRooms(Room roomA, Room roomB)
        {
            roomA.AddRoom(roomB.position);
            roomB.AddRoom(roomA.position);
        }
    }    
}
