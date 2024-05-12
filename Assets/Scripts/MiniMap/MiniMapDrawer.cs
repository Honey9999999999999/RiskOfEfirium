using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapDrawer
    {
        private const string MINIMAP_PATH = "Prefabs/MiniMap/Minimap";
        private const string SIMPLE_ROOM_PATH = "Prefabs/MiniMap/SimpleRoom";

        private static Dictionary<Type, Color32> _roomColorMap = new()
        {
            //[typeof(EnterRoom)] = Color.blue,
            [typeof(TRoom)] = new Color32(0, 255, 125, 255),
            //[typeof(LongRoom)] = Color.gray,
            //[typeof(ExitRoom)] = Color.red
        };

        public static GameObject CreateMiniMap()
        {
            GameObject miniMap = GameObject.Instantiate(Resources.Load<GameObject>(MINIMAP_PATH));
            LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

            foreach (var room in map.rooms)
            {                
                int offset = 100;

                foreach (var block in room.blocks)
                {
                    GameObject drawingRoom = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);
                    drawingRoom.transform.localPosition = new Vector2(block.position.x * offset, block.position.y * offset);

                    GameObject drawingInter = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), drawingRoom.transform);
                    drawingInter.GetComponent<Image>().color = _roomColorMap[room.GetType()];
                    drawingInter.GetComponent<RectTransform>().sizeDelta = new Vector2(90, 90);

                    foreach (var door in block.doors)
                    {
                        GameObject drawingDoor = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), drawingRoom.transform);
                        drawingDoor.GetComponent<Image>().color = Color.magenta;
                        drawingDoor.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 10);
                        drawingDoor.transform.localPosition = new Vector2(door.direction.x * 50, door.direction.y * 50);
                    }
                }                
            }

            return miniMap;
        }

        //public static GameObject CreateMiniMap()
        //{
        //    GameObject miniMap = GameObject.Instantiate(Resources.Load<GameObject>(MINIMAP_PATH));

        //    LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;
        //    List<LabyrinthGenerator.IntVector2> posUsedRoom = new();

        //    foreach (var room in map._map)
        //    {
        //        GameObject simpleRoom = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);
        //        simpleRoom.GetComponent<Image>().color = _roomColorMap[room.GetType()];

        //        int offset = 150;

        //        simpleRoom.transform.localPosition = new Vector3(room.position.x * offset, room.position.y * offset);

        //        foreach (Door busyPass in room.GetBusyPasses())
        //        {
        //            if (IsNotDrawingPath(posUsedRoom, busyPass.path))
        //            {
        //                GameObject line = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);
        //                line.name = "Path";

        //                line.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(50, 50);

        //                GameObject textObj = new("text");
        //                textObj.transform.parent = line.transform;
        //                textObj.transform.localPosition = UnityEngine.Vector2.zero;
        //                TextMeshProUGUI textMeshPro = textObj.AddComponent<TextMeshProUGUI>();

        //                textMeshPro.color = Color.black;
        //                textMeshPro.alignment = TextAlignmentOptions.Center;
        //                textMeshPro.text = busyPass.path.ToString();

        //                UnityEngine.Vector2 pos1 = simpleRoom.transform.localPosition;
        //                UnityEngine.Vector2 pos2 = new(busyPass.path.x * offset, busyPass.path.y * offset);

        //                line.transform.localPosition = (pos1 + pos2) / 2;
        //            }
        //        }

        //        posUsedRoom.Add(room.position);
        //    }

        //    return miniMap;
        //}

        private static bool IsNotDrawingPath(List<LabyrinthGenerator.IntVector2> posUsedRoom, LabyrinthGenerator.IntVector2 path)
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
