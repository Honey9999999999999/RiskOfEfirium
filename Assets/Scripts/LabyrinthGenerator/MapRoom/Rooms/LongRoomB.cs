using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LongRoomB : Room
    {
        public LongRoomB() : base(new List<Block>()
        {
            new SimpleBlock1(new(0, 1), Direction.Top, 0),
            new SimpleBlock1(new(0, 0), Direction.Down, 1)
        })
        {
        }
    }
}
