using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using Maps;
using System;
using UnityEngine;

public class PlayerTransition : MonoBehaviour
{
    public static event Action OnPositionChanged;

    private Player _player;

    private static IntVector2 _position = new(0, 0);
    public static IntVector2 position { get => _position; private set => _position = value; }

    private static IntVector2 _oldPosition = new(0, 0);
    public static IntVector2 oldPosition { get => _oldPosition; private set => _oldPosition = value; }

    [SerializeField] private Direction direction;

    private void Start()
    {
        _player = Game.GetInteractor<PlayerInteractor>().player;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Player>(out _))
        {
            GoOn();
        }
    }

    public void GoOn()
    {
        IntVector2 dir = DirectionHandler.GetDirection(direction);
        LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

        if(map.TryGetRoom(position, out Room playerRoom))
        {
            if (playerRoom.TryGetDoorLeadsTo(direction, out Door door))
            {
                oldPosition = position;
                position = door.targetRoom.position;

                IntVector2 reverseDirection = (oldPosition - position).GetNormilize();

                Vector3 targetPosition = new(position.x * MapCreator.OFFSET, 1, position.y * MapCreator.OFFSET);
                targetPosition += new Vector3(reverseDirection.x, 0, reverseDirection.y) * MapCreator.OFFSET / 4;
                _player.transform.position = targetPosition;

                OnPositionChanged?.Invoke();
            }
        }
        else
        {
            throw new Exception("Next room not find");
        }
    }

    public void Rotate()
    {
        int rotation = (int)direction + 1;
        direction = (Direction)(rotation >= 4 ? 0 : rotation);
    }
}
