using Architecture;
using Assets.Scripts.MiniMap.Configs;
using UnityEngine;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapInteractor : Interactor
    {
        public MiniMapDrawer drawer { get; private set; }
        public GameObject miniMap { get; private set; }

        private IDrawerConfig _config;

        public override void OnCreate()
        {
            base.OnCreate();
            _config = new MinimazeDrawerConfig();
            drawer = new(_config);
        }

        public override void Initialize()
        {
            base.Initialize();

            miniMap = drawer.CreateMiniMap();
            CameraController.OnCameraRotated += RotateMap;
            drawer.OnPlayerPointMoved += CentreMiniMap;

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
        private void RotateMap(Vector3 rotation)
        {
            miniMap.transform.Rotate(new(0, 0, rotation.y));

            CentreMiniMap();
        }

        private void CentreMiniMap()
        {
            miniMap.transform.localPosition = Vector3.zero - (drawer.player.transform.position - drawer.player.transform.parent.transform.position);
        }
    }
}
