using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.MiniMap.Configs;
using Assets.Scripts.Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MapDrawer
{
    public class MiniMapDrawer
    {
        private IDrawerConfig _config;

        private LevelMap _map;

        private GameObject _miniMap;
        private GameObject _player;

        public MiniMapDrawer(IDrawerConfig config)
        {
            _config = config;

            Game.GetInteractor<PlayerPositionInteractor>().OnInitialized += DrawPlayer;
            Game.GetInteractor<PlayerPositionInteractor>().OnPositionChanged += MovePlayer;
        }

        public GameObject CreateMiniMap()
        {
            _miniMap = Instantiater.Instantiate<GameObject>(_config.minimapPath);
            _map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

            foreach (var room in _map.rooms)
            {
                DrawRoom(room);
            }

            return _miniMap;
        }

        private void DrawRoom(Room room)
        {
            GameObject drawingRoom = Instantiater.Instantiate<GameObject>(_config.roomPrefabMap[room.GetType()], _miniMap.transform);
            Vector2 roomPosition = Vector2.zero;

            foreach (var block in room.blocks)
            {
                roomPosition += new Vector2(block.position.x, block.position.y);
            }

            roomPosition /= room.blocks.Count;

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
                Vector2 blockPos = GetBlockPosition(block);

                GameObject drawingDoor = Instantiater.Instantiate<GameObject>(_config.doorPath, _miniMap.transform);
                drawingDoor.GetComponent<Image>().color = door.isLeadSomeWhere ? Color.green : Color.red;
                drawingDoor.GetComponent<RectTransform>().sizeDelta = new Vector2(5, 5);                
                drawingDoor.transform.localPosition = new Vector2(blockPos.x + door.direction.x * _config.textureBlockSize / 4,
                    blockPos.y + door.direction.y * _config.textureBlockSize / 4);

                if (door.isLeadSomeWhere)
                {
                    GameObject drawingHall = Instantiater.Instantiate<GameObject>(_config.hallPath, _miniMap.transform);
                    drawingHall.GetComponent<RectTransform>().sizeDelta = new Vector2(_config.textureBlockSize, _config.textureBlockSize);

                    Rotate(drawingHall, DirectionHandler.GetNameDirection(door.direction));

                    drawingHall.transform.localPosition = new Vector2(blockPos.x + door.direction.x * (_config.textureBlockSize + _config.hallOffset),
                    blockPos.y + door.direction.y * (_config.textureBlockSize + _config.hallOffset));
                }
            }
        }

        private Vector2 GetBlockPosition(Block block)
        {
            return new Vector2(block.position.x, block.position.y) * _config.textureBlockSize;
        }

        private void DrawPlayer()
        {
            _player = Instantiater.Instantiate<GameObject>(_config.playerPath, _miniMap.transform);
            IntVector2 playerPosition = Game.GetInteractor<PlayerPositionInteractor>().position;
            _player.transform.localPosition = new Vector2(playerPosition.x, playerPosition.y) * _config.textureBlockSize;
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

            _player.transform.localPosition = new Vector2(pos.x, pos.y) * _config.textureBlockSize;

            Debug.Log($"{room.type}");
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
