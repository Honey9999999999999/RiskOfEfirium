namespace Assets.Scripts.LabyrinthGenerator.RoomCreators
{
    internal class RoomCreatorConfigMini : RoomCreatorConfigBase
    {
        public RoomCreatorConfigMini() : base()
        {

            ///Основной генератор - шансы комнат

            _roomMap.Add(RoomType.Gateway, new()
            {
                { 1f, RoomType.ResidentialRoom }
            });
            _roomMap.Add(RoomType.ResidentialRoom, new()
            {
                { 1f, RoomType.ResidentialRoom }
            });

            ///Основной генератор - размеры

            
            _sizeMap.Add(RoomType.ResidentialRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomA> },
                { 0.6f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.CommandRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomA> }
            });

            ///Конечный генератор - шансы комнат

            _roomEndMap.Add(RoomType.ResidentialRoom, new()
            {
                { 1f, RoomType.ResidentialRoom }
            });
            _roomEndMap.Add(RoomType.CommandRoom, new()
            {
                { 1f, RoomType.ResidentialRoom }
            });

            ///Конечный генератор - размеры

            _sizeEndMap.Add(RoomType.ResidentialRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
        }
    }
}
