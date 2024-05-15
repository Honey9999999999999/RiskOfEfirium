using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class SimpleBlock2 : Block
    {
        public SimpleBlock2(IntVector2 offsetFromCenter, Direction direction, int countDoors) : base(offsetFromCenter, direction, new List<Door>()
        {
            new Door(Direction.Top),
            new Door(Direction.Down)
        }, countDoors)
        {
        }
    }
}
