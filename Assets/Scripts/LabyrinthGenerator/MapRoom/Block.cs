using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class Block
    {
        private IntVector2 _position;        
        private IntVector2 _offset;

        public Block(IntVector2 offsetFromCenter, List<Door> doors)
        {
            _position = new(0, 0);
            _offset = offsetFromCenter;

            foreach (var door in doors)
            {
                door.selfPosition = position;
            }

            this.doors = doors;
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

        internal void Rotate()
        {
            int x = -offsetFromCenter.y;
            int y = offsetFromCenter.x;

            offsetFromCenter = new(x, y);

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
                door.selfPosition = position;
            }
        }

        public int GetCountDoors()
        {
            return doors.Count;
        }
    }
}
