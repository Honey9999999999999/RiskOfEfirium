using Assets.Scripts.LabyrinthGenerator.Rooms;
using System.Collections.Generic;
using UnityEditor;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class Room
    {
        //protected readonly Dictionary<Position, bool> _directionsMap;
        protected readonly Dictionary<DirectionEnum, Door> _doorMap;

        public abstract int maxCountPasses { get; }

        internal Position position { get; set; }
        public readonly List<Position> occupiedPlaces;

        public Room() : this(new Position(0, 0)) { }
        public Room(Position position)
        {
            //_directionsMap = new Dictionary<Position, bool>();
            _doorMap = new Dictionary<DirectionEnum, Door>();
            this.position = position;            
            AddPasses();
            occupiedPlaces = SetOccupiedPlaces();
        }

        protected abstract void AddPasses();
        protected abstract List<Position> SetOccupiedPlaces();

        public void AddRoom(Position position)
        {
            DirectionEnum direction = DirectionEnum.Down;

            foreach (var key in _doorMap.Keys)
            {
                if (_doorMap[key].path.Equals(position))
                {
                    direction = key;
                    break;
                }
            }

            if (!IsFreePass(direction))
            {
                throw new System.Exception($"Direction {direction} not free!");
            }
            else
            {
                _doorMap[direction].isLeadSomeWhere = true;
            }
        }

        public List<Door> GetFreePasses()
        {
            List<Door> doors = new();

            foreach (var pass in _doorMap)
            {
                if (!pass.Value.isLeadSomeWhere)
                {
                    doors.Add(pass.Value);
                }
            }

            return doors;
        }
        public List<Door> GetBusyPasses()
        {
            List<Door> doors = new();

            foreach (var pass in _doorMap)
            {
                if (pass.Value.isLeadSomeWhere)
                {
                    doors.Add(pass.Value);
                }
            }

            return doors;
        }

        private bool IsFreePass(DirectionEnum direction)
        {
            if (!DoesItBelong(direction))
            {
                throw new System.Exception($"this room have't pass {direction}");
            }

            return !_doorMap[direction].isLeadSomeWhere;
        }

        private bool DoesItBelong(DirectionEnum direction)
        {
            return _doorMap.ContainsKey(direction);
        }
    }
}
