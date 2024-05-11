using Assets.Scripts.LabyrinthGenerator.Rooms;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.GeneratorConfigs
{
    internal class MapGeneratorConfigAdvanced : MapGeneratorConfig
    {
        public const int MAX_ROOMS = 30;
        public override int roomsCount => MAX_ROOMS;

        public override List<Room> CreateLevelMap()
        {
            rooms = new()
            {
                new EnterRoom()
            };

            while (rooms.Count < MAX_ROOMS)
            {
                Room selectedRoom = GetRoom();

                List<Door> freePasses = selectedRoom.GetFreePasses();
                Position selectedPosition = freePasses[random.Next(freePasses.Count)].path;

                Room newRoom;

                if (!IsSomeOneClaims(selectedPosition))
                {
                    if (rooms.Count == MAX_ROOMS - 1)
                    {
                        newRoom = new ExitRoom(selectedPosition);
                    }
                    else
                    {
                        newRoom = new SimpleRoom(selectedPosition);
                    }

                    LinkRooms(selectedRoom, newRoom);

                    rooms.Add(newRoom);
                }
            }

            return rooms;
        }
    }
}
