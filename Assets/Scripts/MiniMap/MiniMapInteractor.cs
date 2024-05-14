using Architecture;
using UnityEngine;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapInteractor : Interactor
    {
        public MiniMapDrawer drawer { get; private set; }
        public GameObject miniMap { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();

            drawer = new();
        }

        public override void Initialize()
        {
            base.Initialize();

            miniMap = drawer.CreateMiniMap();

            Debug.Log("MiniMap Initialized!");
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public void ReDrawMap()
        {
            GameObject.Destroy(miniMap);

            miniMap = drawer.CreateMiniMap();
        }
    }
}
