namespace Assets.Scripts.LabyrinthGenerator
{
    public class Door
    {
        public Door(Direction direction)
        {
            this.Direction = DirectionHandler.GetDirection(direction);

            IsLeadSomeWhere = false;
        }

        public IntVector2 SelfPosition { get; internal set; }
        public IntVector2 Direction { get; private set; }
        public IntVector2 TargetPosition => SelfPosition + Direction;
        public bool IsLeadSomeWhere { get; set; }

        public Room ParentRoom
        {
            get { return parentRoom; }
            internal set
            {
                parentRoom = (parentRoom ??= value);
            }
        }
        private Room parentRoom;
        public Room TargetRoom { get; internal set; }

        internal void Rotate()
        {
            int x = -Direction.y;
            int y = Direction.x;

            Direction = new(x, y);
        }
    }
}
