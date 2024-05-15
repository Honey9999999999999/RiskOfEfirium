using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class SimpleRoomC : Room
    {
        public SimpleRoomC() : base(new()
        {
            new SimpleBlock1 (new(0, 0), Direction.Top, 0)
        })
        {
        }
    }
}
