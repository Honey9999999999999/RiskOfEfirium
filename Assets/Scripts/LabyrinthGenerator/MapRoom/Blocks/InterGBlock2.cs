namespace Assets.Scripts.LabyrinthGenerator
{
    public class InterGBlock2 : Block
    {
        public InterGBlock2(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new()
        {
            new(Direction.Top),
            new(Direction.Left)
        })
        {
        }
    }
}
