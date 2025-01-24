namespace Assets.Scripts.LabyrinthGenerator.RoomCreators
{
    internal class RoomCreatorConfigMini : RoomCreatorConfigBase
    {
        public RoomCreatorConfigMini() : base()
        {

            ///Основной генератор - шансы комнат

            _roomMap.Add(RoomType.Gateway, new()
            {
                { 1f, RoomType.CargoRoom },
                { 1f, RoomType.SecurityRoom }
            });

            _roomMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, RoomType.CargoRoom },
                { .75f, RoomType.LifeSupportRoom }
            });
            _roomMap.Add(RoomType.SecurityRoom, new()
            {
                { 1f, RoomType.RecreationRoom }
            });

            _roomMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 0.3f, RoomType.CargoRoom }
            });

            _roomMap.Add(RoomType.RecreationRoom, new()
            {
                { 0.3f, RoomType.CargoRoom }
            });

            ///Основной генератор - размеры


            _sizeMap.Add(RoomType.RecreationRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomA> },
                { 0.6f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.CargoRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomA> },
                { 0.6f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.SecurityRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.CommandRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomA> }
            });


            ///Генератор комнат без кислорода

            _roomNoOxMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 1f, RoomType.CargoRoom }
            });
            _roomNoOxMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, RoomType.CargoRoom },
                { .5f, RoomType.LifeSupportRoom }
            });

            //Размеры комнат без кислорода

            _sizeNoOxMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomB> }
            });
            _sizeNoOxMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomA> },
                { 1f, CreateRoom<SimpleRoomB> }
            });


            ///Конечный генератор - шансы комнат

            _roomEndMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, RoomType.Armory },
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.Restroom }
            });
            _roomEndMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 1f, RoomType.Armory },
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.Restroom }
            });
            _roomEndMap.Add(RoomType.RecreationRoom, new()
            {
                { 1f, RoomType.Armory },
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.Restroom }
            });
            _roomEndMap.Add(RoomType.SecurityRoom, new()
            {
                { 1f, RoomType.Armory },
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.Restroom }
            });
            _roomEndMap.Add(RoomType.CommandRoom, new()
            {
                { 1f, RoomType.Armory },
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.Restroom }
            });

            ///Конечный генератор - размеры

            _sizeEndMap.Add(RoomType.Armory, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
            _sizeEndMap.Add(RoomType.EngineeringRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
            _sizeEndMap.Add(RoomType.Restroom, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
        }
    }
}
