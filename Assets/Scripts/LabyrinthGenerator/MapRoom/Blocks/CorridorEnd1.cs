namespace Assets.Scripts.LabyrinthGenerator
{
    public class CorridorEnd1 : Block
    {
        public CorridorEnd1(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new()
        {
            new(Direction.Top)
        })
        {
        }
    }
}
