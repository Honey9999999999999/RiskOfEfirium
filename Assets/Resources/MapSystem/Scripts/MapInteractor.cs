using System;
using Architecture;
using Maps;

namespace Assets.Scripts.Map
{
    public class MapInteractor : Interactor
    {
        public event Action OnStarted;
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

            OnStarted?.Invoke();
        }
    }
}
