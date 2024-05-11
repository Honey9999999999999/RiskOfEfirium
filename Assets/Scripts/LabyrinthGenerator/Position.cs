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

        public static Position operator +(Position pos1, Position pos2)
        {
            return new Position(pos1.x + pos2.x, pos1.y + pos2.y);
        }

        public bool Equals(Position pos)
        {
            return x == pos.x && y == pos.y;
        }

        public override string ToString()
        {
            return $"({x};{y})";
        }
    }
}
