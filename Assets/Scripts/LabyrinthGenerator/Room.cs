using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class Room
    {
        private readonly Dictionary<Direction, Room> _rooms;

        internal Position position { get; set; }

        public Room()
        {
            _rooms = new Dictionary<Direction, Room>();
            position = new Position(0, 0);
        }

        public void AddRoom(Direction direction, Room room)
        {
            if (!IsFreePass(direction.name))
            {
                throw new System.Exception($"Direction {direction.name} not free!");
            }

            _rooms[direction] = room;
        }

        public List<DirectionEnum> GetFreePasses()
        {
            List<DirectionEnum> directions = new();

            for (int i = 0; i < 4; i++)
            {
                if (IsFreePass((DirectionEnum)i))
                {
                    directions.Add((DirectionEnum)i);
                }
            }            

            return directions;
        }
        public bool IsFreePass(DirectionEnum direction)
        {
            foreach (var key in _rooms.Keys)
            {
                if(key.name == direction)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Direction> GetDirections()
        {
            return _rooms.Keys.ToList();
        }
    }
}
