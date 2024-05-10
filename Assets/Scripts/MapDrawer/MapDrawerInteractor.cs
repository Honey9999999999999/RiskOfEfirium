using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Assets.Scripts.MapDrawer
{
    public class MapDrawerInteractor : Interactor
    {
        public GameObject miniMap { get; private set; }

        private const string MINIMAP_PATH = "Prefabs/MiniMap/Minimap";
        private const string SIMPLE_ROOM_PATH = "Prefabs/MiniMap/SimpleRoom";

        public void CreateMiniMap()
        {
            miniMap = Object.Instantiate(Resources.Load<GameObject>(MINIMAP_PATH));

            LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

            foreach (var room in map._map)
            {
                GameObject simpleRoom = Object.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);

                int offset = 150;

                simpleRoom.transform.localPosition = new Vector3(room.position.x * offset, room.position.y * offset);

                foreach (var dir in room.GetDirections())
                {
                    GameObject line = Object.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), simpleRoom.transform);

                    line.GetComponent<RectTransform>().sizeDelta = new Vector2(dir.vector.x == 0 ? 50 : 150, dir.vector.y == 0 ? 50 : 150);

                    Vector2 nextRoom = new Vector2(simpleRoom.transform.position.x + 150 * dir.vector.x, simpleRoom.transform.position.y + 150 * dir.vector.y);
                    line.transform.position = new Vector2((simpleRoom.transform.position.x + nextRoom.x) / 2, (simpleRoom.transform.position.y + nextRoom.y) / 2);
                }
            }
        }

        public override void OnCreate()
        {
            base.OnCreate();

            CreateMiniMap();
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
    }
}
