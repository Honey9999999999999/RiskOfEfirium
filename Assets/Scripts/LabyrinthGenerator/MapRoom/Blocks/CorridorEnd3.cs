namespace Assets.Scripts.LabyrinthGenerator
{
    public class CorridorEnd3 : Block
    {
        public CorridorEnd3(IntVector2 offsetFromCenter, Direction direction) : base(offsetFromCenter, direction, new()
        {
            new(Direction.Left),
            new(Direction.Right),
            new(Direction.Top)
        })
        {
        }
    }
}
