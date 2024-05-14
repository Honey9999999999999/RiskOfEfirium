using Architecture;
using Assets.Scripts.LabyrinthGenerator;
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
        private const string PLAYER_PATH = "Prefabs/MiniMap/Player";

        private Dictionary<Type, string> _blockSpriteMap = new()
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

        private LevelMap _map;

        private GameObject _miniMap;
        private GameObject _player;

        public MiniMapDrawer()
        {
            Game.GetInteractor<PlayerPositionInteractor>().OnInitialized += DrawPlayer;
            Game.GetInteractor<PlayerPositionInteractor>().OnPositionChanged += MovePlayer;
        }

        public GameObject CreateMiniMap()
        {
            _miniMap = GameObject.Instantiate(Resources.Load<GameObject>(MINIMAP_PATH));
            _map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

            foreach (var room in _map.rooms)
            {
                DrawRoom(room);
            }

            return _miniMap;
        }

        private void DrawRoom(Room room)
        {
            foreach (var block in room.blocks)
            {
                DrawBlock(block);
                DrawDoors(block);
            }
        }

        private void DrawBlock(Block block)
        {
            GameObject drawingBlock = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), _miniMap.transform);

            Texture2D textureBlock = GameObject.Instantiate(Resources.Load<Texture2D>(_blockSpriteMap[block.GetType()]));
            drawingBlock.GetComponent<Image>().sprite = Sprite.Create(textureBlock, new Rect(0, 0, textureBlock.width, textureBlock.height), Vector2.zero);
            drawingBlock.GetComponent<RectTransform>().sizeDelta = new Vector2(TEXTURE_BLOCK_SIZE, TEXTURE_BLOCK_SIZE);
            drawingBlock.transform.localPosition = GetBlockPosition(block);

            for (int i = 0; i < (int)block.RotatedOn; i++)
            {
                drawingBlock.transform.Rotate(Vector3.forward, 90);
            }
        }

        private void DrawDoors(Block block)
        {
            foreach (var door in block.doors)
            {
                GameObject drawingDoor = GameObject.Instantiate(Resources.Load<GameObject>(SIMPLE_ROOM_PATH), _miniMap.transform);
                drawingDoor.GetComponent<Image>().color = door.isLeadSomeWhere ? Color.green : Color.red;
                drawingDoor.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);
                Vector2 blockPos = GetBlockPosition(block);
                drawingDoor.transform.localPosition = new Vector2(blockPos.x + door.direction.x * TEXTURE_BLOCK_SIZE / 2,
                    blockPos.y + door.direction.y * TEXTURE_BLOCK_SIZE / 2);
            }
        }

        private Vector2 GetBlockPosition(Block block)
        {
            return new Vector2(block.position.x, block.position.y) * TEXTURE_BLOCK_SIZE;
        }

        private void DrawPlayer()
        {
            _player = GameObject.Instantiate(Resources.Load<GameObject>(PLAYER_PATH), _miniMap.transform);
            IntVector2 playerPosition = Game.GetInteractor<PlayerPositionInteractor>().position;
            _player.transform.localPosition = new Vector2(playerPosition.x, playerPosition.y) * TEXTURE_BLOCK_SIZE;
        }
        private void MovePlayer()
        {
            IntVector2 playerPosition = Game.GetInteractor<PlayerPositionInteractor>().position;
            Room room = _map.config.GetRoom(playerPosition);
            Vector2 pos = new(0, 0);

            foreach (var block in room.blocks)
            {
                pos += new Vector2(block.position.x, block.position.y);
            }

            pos /= room.blocks.Count;

            _player.transform.localPosition = new Vector2(pos.x, pos.y) * TEXTURE_BLOCK_SIZE;

            Debug.Log($"{room.type}");
        }
    }
}
