using System.Collections.Generic;

namespace Assets.Scripts.LabyrinthGenerator.RoomCreators
{
    public class RoomCreatorConfigExample : RoomCreatorConfigBase
    {
        public RoomCreatorConfigExample() : base(new Dictionary<float, RoomCreator<Room>>()
        {
            [0.5f] = CreateRandomRoom<SimpleRoom>,
            [0.75f] = CreateRandomRoom<SimpleRoomB>,
            [0.1f] = CreateRandomRoom<MediumRoom>,
            [0.05f] = CreateRandomRoom<BigRoom>,
            [0.15f] = CreateRandomRoom<LongRoomA>,
            [0.25f] = CreateRandomRoom<LongRoomB>,
            [0.005f] = CreateRandomRoom<TRoom>
        })
        {
        }
    }
}
