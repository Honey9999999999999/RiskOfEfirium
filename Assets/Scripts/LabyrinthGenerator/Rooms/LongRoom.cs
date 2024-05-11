using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.Rooms
{
    public class LongRoom : Room
    {
        public LongRoom()
        {
        }

        public LongRoom(Position position) : base(position)
        {
        }

        public override int maxCountPasses => 6;

        protected override void AddPasses()
        {
            _doorMap[Rooms.DirectionEnum.Left] = new(position + new Position(-1, 0));
            _doorMap[Rooms.DirectionEnum.Right] = new(position + new Position(1, 0));
            _doorMap[Rooms.DirectionEnum.Top] = new(position + new Position(0, 1));
            _doorMap[Rooms.DirectionEnum.Down] = new(position + new Position(0, -1));
        }
        protected override List<Position> SetOccupiedPlaces()
        {
            return new List<Position>()
            {
                position
            };
        }
    }
}
