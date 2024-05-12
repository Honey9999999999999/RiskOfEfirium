namespace Assets.Scripts.LabyrinthGenerator
{
    public class IntVector2
    {
        public static IntVector2 zero => new(0, 0);
        public int x { get; private set; }
        public int y { get; private set; }

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static IntVector2 operator +(IntVector2 pos1, IntVector2 pos2)
        {
            return new IntVector2(pos1.x + pos2.x, pos1.y + pos2.y);
        }

        public static IntVector2 operator -(IntVector2 pos1, IntVector2 pos2)
        {
            return new IntVector2(pos1.x - pos2.x, pos1.y - pos2.y);
        }

        public static IntVector2 operator -(IntVector2 pos)
        {
            return new IntVector2(-pos.x, -pos.y);
        }

        public static bool operator ==(IntVector2 pos1, IntVector2 pos2)
        {
            return pos1.x == pos2.x && pos1.y == pos2.y;
        }
        public static bool operator !=(IntVector2 pos1, IntVector2 pos2)
        {
            return pos1.x != pos2.x || pos1.y != pos2.y;
        }

        public override bool Equals(object obj)
        {
            if (obj is not IntVector2)
            {
                return false;
            }

            IntVector2 other = (IntVector2)obj;

            return x == other.x && y == other.y;
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"({x};{y})";
        }

        public IntVector2 GetNormilize()
        {
            return new IntVector2
                (
                    x > 0 ? 1 : x < 0 ? -1 : 0,
                    y > 0 ? 1 : y < 0 ? -1 : 0
                );
        }
    }
}
