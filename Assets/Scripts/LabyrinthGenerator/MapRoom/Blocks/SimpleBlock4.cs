using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class SimpleBlock4 : Block
    {
        public SimpleBlock4(IntVector2 offsetFromCenter, int countDoors) : base(offsetFromCenter, Direction.Top, new List<Door>()
        {
            new(Direction.Left),
            new(Direction.Top),
            new(Direction.Right),            
            new(Direction.Down)
        }, countDoors)
        {
        }
    }
}
