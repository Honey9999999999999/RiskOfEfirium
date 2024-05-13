using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class SimpleBlock1 : Block
    {
        public SimpleBlock1(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new List<Door>()
        {
            new Door(Direction.Top)
        })
        {
        }
    }
}
