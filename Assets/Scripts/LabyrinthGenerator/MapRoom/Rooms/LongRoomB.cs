using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LongRoomB : Room
    {
        public LongRoomB() : base(new List<Block>()
        {
            new Block(new(0, 0), new List<Door>()
            {
                new(Direction.Left)
            }),
            new Block(new(1, 0), new List<Door>()
            {
                new(Direction.Right)
            })
        })
        {
        }
    }
}
