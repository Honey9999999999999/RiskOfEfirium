using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField] protected MovePlayerFSMInstance _moveInstance;
    [SerializeField] private Transform _viewDirection;
    [SerializeField] private PlayerBattleFMSInstance _battlerFSM;

    public PlayerController GetPlayerController()
    {
        return (PlayerController)GetEntityController();
    }
    public MovePlayerFSMInstance GetMoveInstance()
    {
        return _moveInstance;
    }
    public PlayerBattleFMSInstance GetBattleFSM() => _battlerFSM;

    public Transform GetViewPort() => _viewDirection;

    protected override void OnDeath()
    {
        base.OnDeath();

        _moveInstance.EntityDead();
        _battlerFSM.enabled = false;
    }
}
