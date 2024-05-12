using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class TRoom : Room
    {
        public TRoom() : base(new List<Block>()
        {
            new Block(new(-1, 0), new List<Door>()
            {
                new Door(Direction.Left)
            }),
            new Block(new(0, 0), new List<Door>()),
            new Block(new(1, 0), new List<Door>()
            {
                new Door(Direction.Right)
            }),
            new Block(new(0, -1), new List<Door>()
            {
                new Door(Direction.Down)
            }),
        })
        {
        }
    }
}
