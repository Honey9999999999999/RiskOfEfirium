using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.MiniMap.Configs;
using Assets.Scripts.Tools;
using System;
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
            GameObject minimapCanvas = Instantiater.Instantiate<GameObject>(_config.minimapPath);
            miniMap = new GameObject("MiniMap");
            miniMap.transform.parent = minimapCanvas.transform;
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
            GameObject drawingRoom = Instantiater.Instantiate<GameObject>(_config.roomPrefabMap[room.GetType()], miniMap.transform);
            Vector2 roomPosition = room.GetRoomPosition();

            drawingRoom.GetComponent<Image>().color = _config.roomColorMap[room.type];
            drawingRoom.GetComponent<RectTransform>().sizeDelta = new Vector2(room.width, room.height) * _config.textureBlockSize;
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
                GameObject drawingDoor = Instantiater.Instantiate<GameObject>(_config.doorPath, miniMap.transform);

                drawingDoor.GetComponent<Image>().color = door.isLeadSomeWhere ? Color.green : Color.red;
                drawingDoor.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);

                drawingDoor.transform.localPosition = new Vector2(
                    blockPos.x + door.direction.x * _config.textureBlockSize / 4,
                    blockPos.y + door.direction.y * _config.textureBlockSize / 4);

                if (door.isLeadSomeWhere)
                {
                    GameObject drawingHall = Instantiater.Instantiate<GameObject>(_config.hallPath, miniMap.transform);
                    drawingHall.GetComponent<RectTransform>().sizeDelta = new Vector2(_config.textureBlockSize, _config.textureBlockSize);

                    Rotate(drawingHall, DirectionHandler.GetNameDirection(door.direction));

                    drawingHall.transform.localPosition = new Vector2(blockPos.x + door.direction.x * (_config.textureBlockSize + _config.hallOffset),
                    blockPos.y + door.direction.y * (_config.textureBlockSize + _config.hallOffset));
                }
            }
        }

        private void DrawPlayer()
        {
            player = Instantiater.Instantiate<GameObject>(_config.playerPath, miniMap.transform);
            IntVector2 playerPosition = PlayerTransition.position;
            player.transform.localPosition = new Vector2(playerPosition.x, playerPosition.y) * _config.textureBlockSize;
        }
        private void MovePlayer()
        {
            IntVector2 playerPosition = PlayerTransition.position;
            Room room = _map.config.GetRoom(playerPosition);

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
