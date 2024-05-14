using Architecture;
using Assets.Scripts.LabyrinthGenerator;
using System;

public class PlayerPositionInteractor : Interactor
{
    public event Action OnInitialized;
    public event Action OnPositionChanged;

    public IntVector2 position { get; private set; }

    public override void Initialize()
    {
        base.Initialize();

        position = new IntVector2(0, 0);

        OnInitialized?.Invoke();
    }

    public void GoOn(Direction direction)
    {
        IntVector2 dir = DirectionHandler.GetDirection(direction);
        LevelMap map = Game.GetInteractor<LabyrinthInteractor>().levelMap;

        if(map.TryGetRoom(position, out Room playerRoom))
        {
            if (playerRoom.TryGetDoorLeadsTo(direction, out Door door))
            {
                position = door.targetRoom.position;
                OnPositionChanged?.Invoke();
            }
        }
        else
        {
            throw new Exception("Player not on the map");
        }

    }
}
