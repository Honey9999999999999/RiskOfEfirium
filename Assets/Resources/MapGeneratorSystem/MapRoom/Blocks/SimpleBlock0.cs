using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class SimpleBlock0 : Block
    {
        public SimpleBlock0(IntVector2 offsetFromCenter) : base(offsetFromCenter, Direction.Top, new List<Door>())
        {
        }
    }
}
