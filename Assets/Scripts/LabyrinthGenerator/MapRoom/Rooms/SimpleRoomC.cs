using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms
{
    public class SimpleRoomC : Room
    {
        public SimpleRoomC() : base(new()
        {
            new SimpleBlock1 (new(0, 0), Direction.Top)
        })
        {
            variableTypes.Add(0.3f, RoomType.Bathroom);
            variableTypes.Add(0.5f, RoomType.CargoRoom);
            variableTypes.Add(0.4f, RoomType.HibernationRoom);
            variableTypes.Add(0.1f, RoomType.EngineeringRoom);
            variableTypes.Add(0.3f, RoomType.Restroom);
        }

        protected override void SetRandomTypeRoom()
        {
            List<RoomType> roomTypes = GetTypesNearestRooms();

            foreach (var type in roomTypes)
            {
                if(type == RoomType.SecurityRoom)
                {
                    SetTypeRoom(RoomType.Armory);
                }
                if (type == RoomType.MedicalRoom)
                {
                    SetTypeRoom(RoomType.Laboratory);
                }
                if (type == RoomType.ResidentialRoom)
                {
                    SetTypeRoom(RoomType.Bathroom);
                }
            }

            if(type == RoomType.UnTyped)
            {
                SetTypeRoom(variableTypes.GetValue());
            }
        }
    }
}
