namespace Assets.Scripts.LabyrinthGenerator
{
    public class Door
    {
        public Door(Direction direction)
        {
            this.direction = DirectionHandler.GetDirection(direction);

            isLeadSomeWhere = false;
        }

        public IntVector2 selfPosition { get; internal set; }
        public IntVector2 direction { get; private set; }
        public IntVector2 targetPosition => selfPosition + direction;
        public bool isLeadSomeWhere { get; set; }

        public Room targetRoom { get; internal set; }

        internal void Rotate()
        {
            int x = -direction.y;
            int y = direction.x;

            direction = new(x, y);
        }

        public static bool operator ==(Door door1, Door door2)
        {
            return door1.selfPosition == door2.selfPosition && door1.direction == door2.direction;
        }

        public static bool operator !=(Door door1, Door door2)
        {
            return door1.selfPosition != door2.selfPosition || door1.direction != door2.direction;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Door)
            {
                return false;
            }

            Door other = (Door)obj;

            return selfPosition == other.selfPosition && direction == other.direction;
        }
    }
}
