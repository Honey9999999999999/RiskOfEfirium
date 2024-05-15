using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class SimpleRoomA : Room
    {
        public SimpleRoomA() : base(new List<Block>()
        {
            new SimpleBlock4(new(0, 0), 0)
        })
        {
        }
    }
}
