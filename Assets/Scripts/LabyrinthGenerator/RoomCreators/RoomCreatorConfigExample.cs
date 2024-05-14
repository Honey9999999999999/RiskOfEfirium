using Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms;
using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.RoomCreators
{
    public class RoomCreatorConfigExample : RoomCreatorConfigBase
    {
        public RoomCreatorConfigExample() : base()
        {
            _chanceMap.Add(0.5f, CreateRoom<SimpleRoomA>);
            _chanceMap.Add(0.5f, CreateRoom<SimpleRoomB>);
            _chanceMap.Add(0.25f, CreateRoom<LongRoomA>);
            _chanceMap.Add(0.25f, CreateRoom<LongRoomB>);
            _chanceMap.Add(0.15f, CreateRoom<MediumRoom>);
            _chanceMap.Add(0.05f, CreateRoom<BigRoom>);
        }
    }
}
