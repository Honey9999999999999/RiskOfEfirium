using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class LongRoomC : Room
    {
        public LongRoomC() : base(new List<Block>()
        {
            new SimpleBlock1(new(0, 1), Direction.Top),
            new SimpleBlock0(new(0, 0))
        })
        {
        }
    }
}
