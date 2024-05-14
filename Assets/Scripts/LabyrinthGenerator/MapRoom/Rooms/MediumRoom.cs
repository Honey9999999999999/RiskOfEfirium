using System;

namespace Assets.Scripts.LabyrinthGenerator
{
    public class MediumRoom : Room
    {
        public MediumRoom() : base(new()
        {
            new SimpleBlock1(new(0, 1), Direction.Top),
            new SimpleBlock1(new(1, 1), Direction.Right),
            new SimpleBlock1(new(1, 0), Direction.Down),
            new SimpleBlock1(new(0, 0), Direction.Left)
        })
        {
            variableTypes.Add(0.5f, RoomType.RecreationRoom);
            variableTypes.Add(0.5f, RoomType.ResidentialRoom);
        }

        protected override void SetRandomTypeRoom()
        {
            SetTypeRoom(variableTypes.GetValue());
        }
    }
}
