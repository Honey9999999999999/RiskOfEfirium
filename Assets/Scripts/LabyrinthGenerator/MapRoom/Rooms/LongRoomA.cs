using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class LongRoomA : Room
    {
        public LongRoomA() : base(new List<Block>()
        {
            new Block(new(0, 0), new List<Door>()
            {
                new(Direction.Left),
                new(Direction.Top),
                new(Direction.Down)
            }),
            new Block(new(1, 0), new List<Door>()
            {
                new(Direction.Right),
                new(Direction.Top),
                new(Direction.Down)
            })
        })
        {
        }
    }
}
