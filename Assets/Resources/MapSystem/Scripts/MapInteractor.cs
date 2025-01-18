using Architecture;
using Maps;

namespace Assets.Scripts.Map
{
    public class MapInteractor : Interactor
    {
        private MapCreator mapCreator;
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            mapCreator = new MapCreator(new RoomCreatorConfigExample());
            mapCreator.Create3DMap();
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
