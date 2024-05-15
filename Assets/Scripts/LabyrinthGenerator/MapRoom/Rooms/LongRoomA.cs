using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class LongRoomA : Room
    {
        public LongRoomA() : base(new List<Block>()
        {
            new SimpleBlock3(new(0, 1), Direction.Top, 0),
            new SimpleBlock3(new(0, 0), Direction.Down, 3)
        })
        {
        }
    }
}
