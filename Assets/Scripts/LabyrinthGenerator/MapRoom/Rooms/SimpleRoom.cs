using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class SimpleRoom : Room
    {
        public SimpleRoom() : base(new List<Block>()
        {
            new Block(new(0, 0), new List<Door>()
            {
                new(Direction.Left),
                new(Direction.Right),
                new(Direction.Top),
                new(Direction.Down),
            })
        })
        {
        }
    }
}
