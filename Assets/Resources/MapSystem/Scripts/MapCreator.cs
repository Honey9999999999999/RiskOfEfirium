using System.Collections.Generic;
using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using UnityEngine;

namespace Maps
{
    internal class MapCreator
    {
        public const int OFFSET = 60;

        private RoomCreatorConfigBase _config;
        private LevelMap _levelMap;

        public MapCreator(RoomCreatorConfigBase config)
        {
            _config = config;
            _levelMap = Game.GetInteractor<LabyrinthInteractor>().levelMap;
        }

        public void Create3DMap()
        {
            GameObject map = new("Map");

            foreach (var room in _levelMap.rooms)
            {
                GameObject roomObj = _config.GetRoom(room.type, room.GetType());
                roomObj.transform.parent = map.transform;
                room.RoomPrefab = roomObj;
                if (room.type != RoomType.Gateway)
                {
                    Game.OnGameInitialized += () => room.RoomPrefab.SetActive(false);
                }

                Rotate(roomObj, room.RotatedOn);

                Vector2 roomPosition = room.GetRoomPosition();
                roomObj.transform.position = new Vector3(roomPosition.x, 0, roomPosition.y) * OFFSET;
            }
        }

        private void Rotate(GameObject roomObj, Direction direction)
        {
            List<PlayerTransition> transitions = roomObj.GetComponent<DoorsTransitions>().GetTransitions();
            roomObj.GetComponent<DoorsTransitions>().Direction = direction;
            for (int i = 0; i < (int)direction; i++)
            {
                roomObj.transform.Rotate(Vector3.up, -90);

                foreach (var transition in transitions)
                {
                    transition.Rotate();
                }
            }
        }
    }
}
