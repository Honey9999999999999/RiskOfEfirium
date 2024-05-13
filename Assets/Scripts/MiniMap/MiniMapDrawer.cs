using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.LabyrinthGenerator.MapRoom.Rooms;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapDrawer
    {
        private const int TEXTURE_BLOCK_SIZE = 64;

        private const string MINIMAP_PATH = "Prefabs/MiniMap/Minimap";
        private const string SIMPLE_ROOM_PATH = "Prefabs/MiniMap/SimpleRoom";

        private static Dictionary<Type, string> _blockSpriteMap = new()
        {
            [typeof(SimpleBlock1)] = "Sprites/MiniMap/SimpleBlock1",
            [typeof(SimpleBlock2)] = "Sprites/MiniMap/SimpleBlock2",
            [typeof(SimpleBlock4)] = "Sprites/MiniMap/SimpleBlock4",
            [typeof(TBlock)] = "Sprites/MiniMap/TBlock",

            [typeof(CorridorEnd0)] = "Sprites/MiniMap/CorridorEnd0",
            [typeof(CorridorEnd1)] = "Sprites/MiniMap/CorridorEnd1",
            [typeof(CorridorEnd3)] = "Sprites/MiniMap/CorridorEnd3",
            [typeof(CorridorTBlock0)] = "Sprites/MiniMap/CorridorTBlock0",

            [typeof(InterBlock0)] = "Sprites/MiniMap/InterBlock0",
            [typeof(InterTBlock0)] = "Sprites/MiniMap/InterTBlock0",
            [typeof(InterGBlock0)] = "Sprites/MiniMap/InterGBlock0",
            [typeof(InterGBlock1)] = "Sprites/MiniMap/InterGBlock1",
            [typeof(InterGBlock2)] = "Sprites/MiniMap/InterGBlock2"
        };

        public static GameObject CreateMiniMap()
        {
            GameObject miniMap = GameObject.Instantiate(Resources.Load<GameObject>(MINIMAP_PATH));
            LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

            foreach (var room in map.rooms)
            {                
                int offset = TEXTURE_BLOCK_SIZE;

                foreach (var block in room.blocks)
                {
                    GameObject drawingBlock = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);

                    Texture2D textureBlock = GameObject.Instantiate(Resources.Load<Texture2D>(_blockSpriteMap[block.GetType()]));
                    drawingBlock.GetComponent<Image>().sprite = Sprite.Create(textureBlock, new Rect(0, 0, textureBlock.width, textureBlock.height), Vector2.zero);
                    drawingBlock.GetComponent<RectTransform>().sizeDelta = new Vector2(TEXTURE_BLOCK_SIZE, TEXTURE_BLOCK_SIZE);                    
                    drawingBlock.transform.localPosition = new Vector2(block.position.x * offset, block.position.y * offset);

                    for (int i = 0; i < (int)block.RotatedOn; i++)
                    {
                        drawingBlock.transform.Rotate(Vector3.forward, 90);
                    }
                    

                    foreach (var door in block.doors)
                    {
                        GameObject drawingDoor = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), miniMap.transform);
                        drawingDoor.GetComponent<Image>().color = door.isLeadSomeWhere ? Color.green : Color.red;
                        drawingDoor.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
                        drawingDoor.transform.localPosition = new Vector2(drawingBlock.transform.localPosition.x + door.direction.x * TEXTURE_BLOCK_SIZE / 2, 
                            drawingBlock.transform.localPosition.y + door.direction.y * TEXTURE_BLOCK_SIZE / 2);                     
                    }
                }                
            }

            return miniMap;
        }
    }
}
