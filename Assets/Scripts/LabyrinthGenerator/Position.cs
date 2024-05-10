namespace Assets.Scripts.LabyrinthGenerator
{
    public class Position
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position GetPosition(DirectionEnum direction)
        {
            int x = direction == DirectionEnum.Left ? -1 : direction == DirectionEnum.Right ? 1 : 0;
            int y = direction == DirectionEnum.Down ? -1 : direction == DirectionEnum.Top ? 1 : 0;

            return new Position(this.x + x, this.y + y);
        }
    }
}
