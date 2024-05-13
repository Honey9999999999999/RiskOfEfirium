using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class InterBlock0 : Block
    {
        public InterBlock0(IntVector2 offsetFromCenter) : base(offsetFromCenter, Direction.Top, new List<Door>())
        {
        }
    }
}
