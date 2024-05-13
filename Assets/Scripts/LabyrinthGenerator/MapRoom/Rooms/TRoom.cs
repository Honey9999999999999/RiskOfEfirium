using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class TRoom : Room
    {
        public TRoom() : base(new List<Block>()
        {
            new CorridorEnd1(new(-1, 0), Direction.Left),
            new CorridorTBlock0(new(0, 0), Direction.Down),
            new CorridorEnd1(new(1, 0), Direction.Right),
            new CorridorEnd1(new(0, 1), Direction.Top),
        })
        {
        }
    }
}
