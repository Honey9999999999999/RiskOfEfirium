using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class TBlock : Block
    {
        public TBlock(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new List<Door>()
        {
            new(Direction.Left),
            new(Direction.Right),
            new(Direction.Top)
        })
        {
        }
    }
}
