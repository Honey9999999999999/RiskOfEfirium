using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class LongRoomB : Room
    {
        public LongRoomB() : base(new List<Block>()
        {
            new CorridorEnd1(new(0, 1), Direction.Top),
            new CorridorEnd1(new(0, 0), Direction.Down)
        })
        {
            variableTypes.Add(0.5f, RoomType.Diner);
        }

        protected override void SetRandomTypeRoom()
        {
            SetTypeRoom(variableTypes.GetValue());
        }
    }
}
