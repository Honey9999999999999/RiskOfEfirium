using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.LabyrinthGenerator.Rooms;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapDrawer
    {
        private const string MINIMAP_PATH = "Prefabs/MiniMap/Minimap";
        private const string SIMPLE_ROOM_PATH = "Prefabs/MiniMap/SimpleRoom";

        private static Dictionary<Type, Color> _roomColorMap = new()
        {
            [typeof(EnterRoom)] = Color.blue,
            [typeof(SimpleRoom)] = Color.white,
            [typeof(ExitRoom)] = Color.red
        };

        public static GameObject CreateMiniMap()
        {
            GameObject miniMap = GameObject.Instantiate(Resources.Load<GameObject>(MINIMAP_PATH));

            LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;
            List<Position> posUsedRoom = new();

            foreach (var room in map._map)
            {
                GameObject simpleRoom = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);
                simpleRoom.GetComponent<Image>().color = _roomColorMap[room.GetType()];

                int offset = 150;

                simpleRoom.transform.localPosition = new Vector3(room.position.x * offset, room.position.y * offset);

                foreach (Door busyPass in room.GetBusyPasses())
                {
                    if (IsNotDrawingPath(posUsedRoom, busyPass.path))
                    {
                        GameObject line = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);
                        line.name = "Path";

                        line.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);

                        GameObject textObj = new("text");
                        textObj.transform.parent = line.transform;
                        textObj.transform.localPosition = Vector2.zero;
                        TextMeshProUGUI textMeshPro = textObj.AddComponent<TextMeshProUGUI>();

                        textMeshPro.color = Color.black;
                        textMeshPro.alignment = TextAlignmentOptions.Center;
                        textMeshPro.text = busyPass.path.ToString();

                        Vector2 pos1 = simpleRoom.transform.localPosition;
                        Vector2 pos2 = new(busyPass.path.x * offset, busyPass.path.y * offset);

                        line.transform.localPosition = (pos1 + pos2) / 2;
                    }
                }

                posUsedRoom.Add(room.position);
            }

            return miniMap;
        }

        private static bool IsNotDrawingPath(List<Position> posUsedRoom, Position path)
        {
            bool isDrawing = false;

            foreach (var pos in posUsedRoom)
            {
                if (pos.Equals(path))
                {
                    isDrawing = true;
                }
            }

            return !isDrawing;
        }
    }
}
