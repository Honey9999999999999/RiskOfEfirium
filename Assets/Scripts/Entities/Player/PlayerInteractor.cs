using Architecture;
using Assets.Scripts.Tools;
using UnityEngine;

public class PlayerInteractor : Interactor
{
    private const string PLAYER_PATH = "Prefabs/Player/Player";
    private Player _player;
    public Player player => _player;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        GameObject playerObj = Instantiater.Instantiate<GameObject>(PLAYER_PATH);
        playerObj.transform.position = new Vector3(0, 1, 0);
        
        if(!playerObj.TryGetComponent(out _player))
        {
            throw new System.Exception("playerObj has't script \"Player\"");
        }
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
