using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class MapGeneratorConfigExample : MapGeneratorConfig
    {
        public const int MAX_ROOMS = 30;
        public override int roomsCount => MAX_ROOMS;

        public Random random;

        public MapGeneratorConfigExample()
        {
            random = new Random();
        }

        public override List<Room> CreateLevelMap()
        {
            List<Room> rooms = new()
            {
                new SimpleRoom()
            };

            for (int i = 0; i < MAX_ROOMS; i++)
            {
                Room room = GetRoom(rooms);                

                List<DirectionEnum> freePasses = room.GetFreePasses();
                Direction direction = new(freePasses[random.Next(freePasses.Count)]);
                Position position = room.position.GetPosition(direction.name);

                Room newRoom;

                bool isRoomPos = false;

                foreach (var item in rooms)
                {
                    if(item.position == position)
                    {
                        newRoom = item;

                        room.AddRoom(direction, newRoom);
                        newRoom.AddRoom(Direction.GetReverseDirection(direction), room);

                        rooms.Add(newRoom);

                        isRoomPos = true;
                        i--;
                    }
                }

                if (!isRoomPos)
                {
                    newRoom = new SimpleRoom
                    {
                        position = position
                    };

                    room.AddRoom(direction, newRoom);
                    newRoom.AddRoom(Direction.GetReverseDirection(direction), room);

                    rooms.Add(newRoom);
                }
            }

            return rooms;
        }

        private Room GetRoom(List<Room> rooms)
        {
            Room room;
            bool isChoosed = false;

            do
            {
                room = rooms[random.Next(rooms.Count)];

                int numberFreePasses = room.GetFreePasses().Count;

                if (numberFreePasses > random.Next(4))
                {
                    isChoosed = true;
                }
            } 
            while (!isChoosed);

            return room;
        }
    }
}
