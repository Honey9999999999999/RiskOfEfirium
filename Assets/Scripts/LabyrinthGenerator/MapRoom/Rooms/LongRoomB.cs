using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LongRoomB : Room
    {
        public LongRoomB() : base(new List<Block>()
        {
            new CorridorEnd1(new(0, 1), Direction.Top),
            new CorridorEnd1(new(0, 0), Direction.Down)
        })
        {
        }
    }
}
