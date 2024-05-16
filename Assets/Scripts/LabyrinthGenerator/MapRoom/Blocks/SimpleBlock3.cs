using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class SimpleBlock3 : Block
    {
        public SimpleBlock3(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new List<Door>()
        {
            new(Direction.Left),
            new(Direction.Top),
            new(Direction.Right)            
        })
        {
        }
    }
}
