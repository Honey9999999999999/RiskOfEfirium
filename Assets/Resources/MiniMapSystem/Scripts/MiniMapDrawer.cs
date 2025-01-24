using System;
using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.MiniMap.Configs;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapDrawer
    {
        public event Action OnPlayerPointMoved;

        private IDrawerConfig _config;
        private LevelMap _map;

        public GameObject miniMap { get; private set; }
        public GameObject player { get; private set; }

        public MiniMapDrawer(IDrawerConfig config)
        {
            _config = config;

            PlayerTransition.OnPositionChanged += MovePlayer;
        }

        public GameObject CreateMiniMap()
        {
            GameObject miniMapUI = Game.GetInteractor<PlayerUIInteractor>().MiniMap;
            Mask mask = miniMapUI.GetComponentInChildren<Mask>();

            miniMap = new GameObject("MiniMapObj");
            miniMap.transform.parent = mask.transform;
            miniMap.transform.localPosition = Vector3.zero;

            _map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

            foreach (var room in _map.rooms)
            {
                DrawRoom(room);
            }

            DrawPlayer();

            return miniMap;
        }

        private void DrawRoom(Room room)
        {
            GameObject drawingRoom = ResourceLoader.Load<GameObject>(_config.roomPrefabMap[room.GetType()], miniMap.transform);
            Vector2 roomPosition = room.GetRoomPosition();

            drawingRoom.GetComponent<Image>().color = _config.roomColorMap[room.type];
            drawingRoom.GetComponent<RectTransform>().sizeDelta = new Vector2(room.width, room.height) * _config.textureBlockSize;

            if (!room.presenceOfOxygen)
            {
                Image image = ResourceLoader.Load<Image>("MiniMapSystem/Prefabs/Minimaze/Oxygen", drawingRoom.transform);
                image.SetNativeSize();
            }            

            drawingRoom.transform.localPosition = roomPosition * _config.textureBlockSize;

            Rotate(drawingRoom, room.RotatedOn);

            foreach (var block in room.blocks)
            {
                DrawDoors(block);
            }
        }

        private void DrawDoors(Block block)
        {
            foreach (var door in block.doors)
            {
                Vector2 blockPos = new Vector2(block.position.x, block.position.y) * _config.textureBlockSize;
                GameObject drawingDoor = ResourceLoader.Load<GameObject>(_config.doorPath, miniMap.transform);

                drawingDoor.GetComponent<Image>().color = door.IsLeadSomeWhere ? Color.green : Color.red;
                drawingDoor.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);

                drawingDoor.transform.localPosition = new Vector2(
                    blockPos.x + door.Direction.x * _config.textureBlockSize / 4,
                    blockPos.y + door.Direction.y * _config.textureBlockSize / 4);

                if (door.IsLeadSomeWhere)
                {
                    GameObject drawingHall = ResourceLoader.Load<GameObject>(_config.hallPath, miniMap.transform);
                    drawingHall.GetComponent<RectTransform>().sizeDelta = new Vector2(_config.textureBlockSize, _config.textureBlockSize);

                    Rotate(drawingHall, DirectionHandler.GetNameDirection(door.Direction));

                    drawingHall.transform.localPosition = new Vector2(blockPos.x + door.Direction.x * (_config.textureBlockSize + _config.hallOffset),
                    blockPos.y + door.Direction.y * (_config.textureBlockSize + _config.hallOffset));
                }
            }
        }

        private void DrawPlayer()
        {
            player = ResourceLoader.Load<GameObject>(_config.playerPath, miniMap.transform);
            IntVector2 playerPosition = PlayerTransition.position;
            player.transform.localPosition = new Vector2(playerPosition.x, playerPosition.y) * _config.textureBlockSize;
        }
        private void MovePlayer(Room room)
        {
            Vector2 pos = room.GetRoomPosition();
            player.transform.localPosition = new Vector2(pos.x, pos.y) * _config.textureBlockSize;

            OnPlayerPointMoved?.Invoke();
        }

        private void Rotate(GameObject obj, Direction direction)
        {
            for (int i = 0; i < (int)direction; i++)
            {
                obj.transform.Rotate(Vector3.forward, 90);
            }
        }
    }
}
