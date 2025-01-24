using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class Block
    {
        private IntVector2 _position;
        private IntVector2 _offset;

        public Block(IntVector2 offsetFromCenter, Direction direction, List<Door> doors)
        {
            _position = new(0, 0);
            _offset = offsetFromCenter;

            for (int i = 0; i < doors.Count; i++)
            {
                doors[i].SelfPosition = position;
            }

            this.doors = doors;

            RotateToDirection(direction);
        }

        public List<Door> doors { get; }

        public IntVector2 position => _position + offsetFromCenter;
        public IntVector2 offsetFromCenter
        {
            get
            {
                return _offset;
            }
            internal set
            {
                _offset = value;
                SetDoorsInPosition();
            }
        }
        public Direction RotatedOn { get; private set; }

        public Room ParentRoom
        {
            get { return parentRoom; }
            internal set
            {
                if(parentRoom == null)
                {
                    parentRoom = value;

                    foreach(Door door in doors)
                    {
                        door.ParentRoom = parentRoom;
                    }
                }
            }
        }
        private Room parentRoom;

        private void RotateToDirection(Direction direction)
        {
            int rotationCount = (int)direction;

            for (int i = 0; i < rotationCount; i++)
            {
                RotateDoors();
            }

            RotatedOn = direction;
        }

        public int GetCountDoors()
        {
            return doors.Count;
        }

        public bool TryGetDoorLeadsTo(Direction direction, out Door door)
        {
            IntVector2 dir = DirectionHandler.GetDirection(direction);

            foreach (var d in doors)
            {
                if (d.IsLeadSomeWhere && d.Direction == dir)
                {
                    door = d;
                    return true;
                }
            }

            door = null;
            return false;
        }

        internal void Rotate()
        {
            int x = -offsetFromCenter.y;
            int y = offsetFromCenter.x;

            offsetFromCenter = new(x, y);

            RotateDoors();

            int rotation = (int)RotatedOn + 1;
            RotatedOn = (Direction)(rotation >= 4 ? 0 : rotation);
        }
        private void RotateDoors()
        {
            foreach (var door in doors)
            {
                door.Rotate();
            }
        }

        internal void SetInPosition(IntVector2 position)
        {
            _position = position;
            SetDoorsInPosition();
        }

        private void SetDoorsInPosition()
        {
            foreach (var door in doors)
            {
                door.SelfPosition = position;
            }
        }
    }
}
