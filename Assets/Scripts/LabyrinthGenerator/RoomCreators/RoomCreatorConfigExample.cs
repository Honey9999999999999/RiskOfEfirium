namespace Assets.Scripts.LabyrinthGenerator.RoomCreators
{
    public class RoomCreatorConfigExample : RoomCreatorConfigBase
    {
        public RoomCreatorConfigExample() : base()
        {

            ///Основной генератор - шансы комнат

            _roomMap.Add(RoomType.Gateway, new()
            {
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.ResidentialRoom }
            });
            _roomMap.Add(RoomType.EngineeringRoom, new()
            {
                { 0.3f, RoomType.CargoRoom },
                { 0.3f, RoomType.ResidentialRoom },
                { 0.2f, RoomType.LifeSupportRoom }
            });
            _roomMap.Add(RoomType.ResidentialRoom, new()
            {
                { 0.4f, RoomType.Diner },
                { 0.3f, RoomType.RecreationRoom },
                { 0.2f, RoomType.HibernationRoom }
            });
            _roomMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 0.7f, RoomType.Arboretum },
                { 0.3f, RoomType.CargoRoom }
            });
            _roomMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, RoomType.CargoRoom },
                { 1f, RoomType.EngineeringRoom },
                { 1f, RoomType.LifeSupportRoom }
            });
            _roomMap.Add(RoomType.Arboretum, new()
            {
                { 1f, RoomType.RecreationRoom },
                { 1f, RoomType.ResidentialRoom }
            });
            _roomMap.Add(RoomType.RecreationRoom, new()
            {
                { 1f, RoomType.SecurityRoom },
                { 1f, RoomType.MedicalRoom }
            });
            _roomMap.Add(RoomType.SecurityRoom, new()
            {
                { 1f, RoomType.EngineeringRoom }
            });
            _roomMap.Add(RoomType.MedicalRoom, new()
            {
                { 1f, RoomType.HibernationRoom }
            });
            _roomMap.Add(RoomType.HibernationRoom, new()
            {
                { 1f, RoomType.Diner },
                { 1f, RoomType.ResidentialRoom },
                { 1f, RoomType.RecreationRoom },
            });
            _roomMap.Add(RoomType.Diner, new()
            {
                { 0.1f, RoomType.Diner },
                { 0.4f, RoomType.ResidentialRoom },
                { 0.4f, RoomType.RecreationRoom },
            });

            ///Основной генератор - размеры

            _sizeMap.Add(RoomType.CargoRoom, new()
            {
                { 0.4f, CreateRoom<SimpleRoomA> },
                { 0.6f, CreateRoom<LongRoomA> }
            });
            _sizeMap.Add(RoomType.Arboretum, new()
            {
                { 0.2f, CreateRoom<MediumRoom> },
                { 0.8f, CreateRoom<SimpleRoomA> }
            });
            _sizeMap.Add(RoomType.CommandRoom, new()
            {
                { 1f, CreateRoom<BigRoom> }
            });
            _sizeMap.Add(RoomType.Diner, new()
            {
                { 0.6f, CreateRoom<SimpleRoomB> },
                { 0.4f, CreateRoom<LongRoomB> }
            });
            _sizeMap.Add(RoomType.EngineeringRoom, new()
            {
                { 0.4f, CreateRoom<LongRoomB> }
            });
            _sizeMap.Add(RoomType.HibernationRoom, new()
            {
                { 0.6f, CreateRoom<SimpleRoomA> },
                { 0.4f, CreateRoom<MediumRoom> }
            });
            _sizeMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 0.4f, CreateRoom<MediumRoom> }
            });
            _sizeMap.Add(RoomType.MedicalRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.RecreationRoom, new()
            {
                { 0.4f, CreateRoom<MediumRoom> },
                { 0.6f, CreateRoom<SimpleRoomA> }
            });
            _sizeMap.Add(RoomType.ResidentialRoom, new()
            {
                { 0.4f, CreateRoom<MediumRoom> },
                { 0.6f, CreateRoom<SimpleRoomB> }
            });
            _sizeMap.Add(RoomType.SecurityRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomB> }
            });

            ///Конечный генератор - шансы комнат

            _roomEndMap.Add(RoomType.EngineeringRoom, new()
            {
                { 0.4f, RoomType.CargoRoom }
            });
            _roomEndMap.Add(RoomType.ResidentialRoom, new()
            {
                { 0.4f, RoomType.Bathroom },
                { 0.3f, RoomType.Restroom }
            });
            _roomEndMap.Add(RoomType.LifeSupportRoom, new()
            {
                { 0.7f, RoomType.Arboretum },
                { 0.3f, RoomType.CargoRoom }
            });
            _roomEndMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, RoomType.CargoRoom }
            });
            _roomEndMap.Add(RoomType.Arboretum, new()
            {
                { 1f, RoomType.CargoRoom },
                { 1f, RoomType.Arboretum },
                { 1f, RoomType.Laboratory }
            });
            _roomEndMap.Add(RoomType.RecreationRoom, new()
            {
                { 1f, RoomType.Restroom },
                { 1f, RoomType.Bathroom }
            });
            _roomEndMap.Add(RoomType.SecurityRoom, new()
            {
                { 1f, RoomType.Armory }
            });
            _roomEndMap.Add(RoomType.MedicalRoom, new()
            {
                { 1f, RoomType.Laboratory }
            });
            _roomEndMap.Add(RoomType.HibernationRoom, new()
            {
                { 1f, RoomType.Restroom },
                { 1f, RoomType.Bathroom },
            });
            _roomEndMap.Add(RoomType.Diner, new()
            {
                { 0.1f, RoomType.Restroom }
            });
            _roomEndMap.Add(RoomType.CommandRoom, new()
            {
                { 0.1f, RoomType.Restroom }
            });

            ///Конечный генератор - размеры

            _sizeEndMap.Add(RoomType.CargoRoom, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
            _sizeEndMap.Add(RoomType.Bathroom, new()
            {
                { 0.8f, CreateRoom<SimpleRoomC> },
                { 0.2f, CreateRoom<LongRoomC> }
            });
            _sizeEndMap.Add(RoomType.Restroom, new()
            {
                { 0.8f, CreateRoom<SimpleRoomC> },
                { 0.2f, CreateRoom<LongRoomC> }
            });
            _sizeEndMap.Add(RoomType.Arboretum, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
            _sizeEndMap.Add(RoomType.Laboratory, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
            _sizeEndMap.Add(RoomType.Armory, new()
            {
                { 1f, CreateRoom<SimpleRoomC> }
            });
        }
    }
}
