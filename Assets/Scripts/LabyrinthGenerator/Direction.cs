namespace Assets.Scripts.LabyrinthGenerator
{
    public class Direction
    {
        public readonly DirectionEnum name;
        public readonly Position vector;

        public Direction(DirectionEnum direction)
        {
            name = direction;

            int x = direction == DirectionEnum.Left ? -1 : direction == DirectionEnum.Right ? 1 : 0;
            int y = direction == DirectionEnum.Down ? -1 : direction == DirectionEnum.Top ? 1 : 0;

            vector = new Position(x, y);
        }

        public static Direction GetReverseDirection(Direction direction)
        {
            return direction.name switch
            {
                DirectionEnum.Left => new Direction(DirectionEnum.Right),
                DirectionEnum.Right => new Direction(DirectionEnum.Left),
                DirectionEnum.Top => new Direction(DirectionEnum.Down),
                DirectionEnum.Down => new Direction(DirectionEnum.Top),
                _ => throw new System.Exception("Imposible"),
            };
        }
    }
}
