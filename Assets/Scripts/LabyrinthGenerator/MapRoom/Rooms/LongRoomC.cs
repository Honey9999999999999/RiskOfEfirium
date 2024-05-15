using System;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms
{
    internal class LongRoomC : Room
    {
        public LongRoomC() : base(new List<Block>()
        {
            new SimpleBlock1(new(0, 1), Direction.Top),
            new SimpleBlock0(new(0, 0))
        })
        {
            variableTypes.Add(0.3f, RoomType.Bathroom);
            variableTypes.Add(0.2f, RoomType.Diner);
        }

        protected override void SetRandomTypeRoom()
        {
            List<RoomType> roomTypes = GetTypesNearestRooms();

            foreach (var type in roomTypes)
            {
                if (type == RoomType.ResidentialRoom)
                {
                    SetTypeRoom(variableTypes.GetValue());
                }
                if(type == RoomType.CargoRoom)
                {
                    SetTypeRoom(RoomType.CargoRoom);
                }
            }
            
            if (type == RoomType.UnTyped)
            {
                SetTypeRoom(variableTypes.GetValue());
            }                
        }
    }
}
