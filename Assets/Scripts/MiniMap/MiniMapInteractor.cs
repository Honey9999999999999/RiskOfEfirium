using Architecture;
using UnityEngine;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapInteractor : Interactor
    {
        public GameObject miniMap { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();

            miniMap = MiniMapDrawer.CreateMiniMap();
        }

        public override void Initialize()
        {
            base.Initialize();

            Debug.Log("MiniMap Initialized!");
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public void ReDrawMap()
        {
            GameObject.Destroy(miniMap);

            miniMap = MiniMapDrawer.CreateMiniMap();
        }
    }
}
