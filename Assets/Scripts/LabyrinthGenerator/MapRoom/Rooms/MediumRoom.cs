using System;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class MediumRoom : Room
    {
        public MediumRoom() : base(new()
        {
            new SimpleBlock1(new(0, 0), Direction.Left, 0),
            new SimpleBlock1(new(0, 1), Direction.Top, 1),
            new SimpleBlock1(new(1, 1), Direction.Right, 2),
            new SimpleBlock1(new(1, 0), Direction.Down, 3)
            
        })
        {
        }
    }
}
