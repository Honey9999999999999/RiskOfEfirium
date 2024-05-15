namespace Assets.Scripts.LabyrinthGenerator.RoomCreators
{
    public class RoomCreatorConfigExample : RoomCreatorConfigBase
    {
        public RoomCreatorConfigExample() : base()
        {
            _roomMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, RoomType.CargoRoom }
            });

            _sizeMap.Add(RoomType.CargoRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomA> }
            });
        }
    }
}
