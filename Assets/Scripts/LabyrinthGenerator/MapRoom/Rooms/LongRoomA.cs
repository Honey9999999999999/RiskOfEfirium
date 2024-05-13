using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class LongRoomA : Room
    {
        public LongRoomA() : base(new List<Block>()
        {
            new CorridorEnd3(new(0, 1), Direction.Top),
            new CorridorEnd3(new(0, 0), Direction.Down)
        })
        {
        }
    }
}
