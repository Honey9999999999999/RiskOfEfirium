using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public abstract class Room
    {
        public Room(List<Block> blocks)
        {
            this.blocks = blocks;
            CalculateCountDoors();
            position = new(0, 0);
            variableTypes = new();
        }

        public List<Block> blocks { get; }
        public int countDoors { get; private set; }
        public IntVector2 position { get; private set; }

        public RoomType type { get; private set; }
        protected ControlRandomList<RoomType> variableTypes;


        public void RandomRotate()
        {
            int count = new Random().Next(4);

            for (int i = 0; i < count; i++)
            {
                Rotate();
            }
        }

        public void Rotate()
        {
            foreach (var block in blocks)
            {
                block.Rotate();
            }
        }

        public void SetInPosition(IntVector2 position)
        {
            this.position = position;

            foreach (var block in blocks)
            {
                block.SetInPosition(position);
            }
        }

        public Block GetBlock(IntVector2 position)
        {
            if (TryGetBlock(position, out Block block))
            {
                return block;
            }

            throw new Exception("this room has't that block");
        }
        public bool TryGetBlock(IntVector2 position, out Block block)
        {
            foreach (var checkingBlock in blocks)
            {
                if (checkingBlock.position == position)
                {
                    block = checkingBlock;
                    return true;
                }
            }

            block = null;
            return false;
        }

        public void OverrideCenter(Block block)
        {
            IntVector2 vector2 = new(block.offsetFromCenter.x, block.offsetFromCenter.y);
            OverrideCenter(vector2);
        }
        public void OverrideCenter(IntVector2 position)
        {
            foreach (var block in blocks)
            {
                block.offsetFromCenter -= position;
            }
        }
        public List<IntVector2> GetOccupiedPosition()
        {
            List<IntVector2> positions = new();

            foreach (var block in blocks)
            {
                positions.Add(block.position);
            }

            return positions;
        }

        public bool TryGetDoorLeadsTo(Direction direction, out Door door)
        {
            foreach (var block in blocks)
            {
                if (block.TryGetDoorLeadsTo(direction, out door))
                {
                    return true;
                }
            }

            door = null;
            return false;
        }

        private void CalculateCountDoors()
        {
            foreach (var block in blocks)
            {
                countDoors += block.GetCountDoors();
            }
        }

        internal void DefineRoomType()
        {
            if (type == RoomType.UnTyped)
            {
                SetRandomTypeRoom();
            }
        }
        protected abstract void SetRandomTypeRoom();
        internal void SetTypeRoom(RoomType type)
        {
            this.type = type;
        }
        protected List<RoomType> GetTypesNearestRooms()
        {
            List<RoomType> roomTypes = new();

            foreach (var block in blocks)
            {
                foreach (var door in block.doors)
                {
                    if (door.isLeadSomeWhere)
                    {
                        roomTypes.Add(door.targetRoom.type);
                    }                    
                }
            }

            return roomTypes;
        }

        public override string ToString()
        {
            return GetType().ToString();
        }
    }
}
