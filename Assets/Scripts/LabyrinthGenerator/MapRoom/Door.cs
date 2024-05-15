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
        public int index { get; internal set; }

        public Room targetRoom { get; internal set; }

        internal void Rotate()
        {
            int x = -direction.y;
            int y = direction.x;

            direction = new(x, y);
        }
    }
}
