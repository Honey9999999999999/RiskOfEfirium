namespace Assets.Scripts.LabyrinthGenerator
{
    public enum Direction
    {
        Top,
        Down,
        Left,
        Right
    }
    public static class DirectionHandler
    {
        public static IntVector2 GetDirection(Direction direction)
        {
            return direction switch
            {
                Direction.Top => new(0, 1),
                Direction.Down => new(0, -1),
                Direction.Left => new(-1, 0),
                Direction.Right => new(1, 0),
                _ => throw new System.Exception($"This direction \"{direction}\" does not exist"),
            };
        }

        public static Direction GetNameDirection(IntVector2 vector2)
        {
            IntVector2 vector = vector2.GetNormilize();
            int value = vector.x + vector.y;

            return value switch
            {
                1 => vector.x == 1 ? Direction.Right : Direction.Top,
                -1 => vector.x == -1 ? Direction.Left : Direction.Down,
                _ => throw new System.Exception($"This direction \"{vector2.GetNormilize()}\" does not exist in this system"),
            };
        }
    }
}
