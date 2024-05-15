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
            variableTypes.Add(0.2f, RoomType.HibernationRoom);
            variableTypes.Add(0.3f, RoomType.Restroom);
        }

        protected override void SetRandomTypeRoom()
        {
            List<RoomType> roomTypes = GetTypesNearestRooms();

            foreach (var type in roomTypes)
            {
                if(type == RoomType.SecurityRoom)
                {
                    if (new Random().Next(0, 2) == 1)
                    {
                        SetTypeRoom(RoomType.Armory);                        
                    }
                    else
                    {
                        SetTypeRoom(RoomType.EngineeringRoom);
                    }
                }
                if (type == RoomType.MedicalRoom)
                {
                    SetTypeRoom(RoomType.Laboratory);
                }
                if (type == RoomType.ResidentialRoom)
                {
                    SetTypeRoom(variableTypes.GetValue());
                }
                if (type == RoomType.CargoRoom)
                {
                    SetTypeRoom(RoomType.CargoRoom);
                }
                if(type == RoomType.Diner)
                {
                    SetTypeRoom(RoomType.Restroom);
                }
            }

            if(type == RoomType.UnTyped)
            {
                SetTypeRoom(variableTypes.GetValue());
            }
        }
    }
}
