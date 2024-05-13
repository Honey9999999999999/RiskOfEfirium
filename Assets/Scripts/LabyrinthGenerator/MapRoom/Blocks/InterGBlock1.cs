namespace Assets.Scripts.LabyrinthGenerator
{
    public class InterGBlock1 : Block
    {
        public InterGBlock1(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new()
        {
            new(Direction.Top)
        })
        {
        }
    }
}
