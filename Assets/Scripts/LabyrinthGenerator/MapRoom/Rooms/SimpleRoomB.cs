using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator
{
    internal class SimpleRoomB : Room
    {
        public SimpleRoomB() : base(new()
        {
            new SimpleBlock2(new(0, 0), Direction.Top)
        })
        {
            variableTypes.Add(1, RoomType.ResidentialRoom);
            variableTypes.Add(1, RoomType.RecreationRoom);
            variableTypes.Add(0.2f, RoomType.SecurityRoom);
            variableTypes.Add(0.2f, RoomType.MedicalRoom);
        }

        protected override void SetRandomTypeRoom()
        {
            SetTypeRoom(variableTypes.GetValue());
        }
    }
}
