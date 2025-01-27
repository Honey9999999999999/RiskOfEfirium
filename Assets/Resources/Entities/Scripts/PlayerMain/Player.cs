using Assets.Resources.Entities.Scripts;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.CraftSystem.PersonalCards;
using Assets.Scripts.Entities;
using Assets.Scripts.Movement;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField] private Transform _viewDirection;
    [SerializeField] protected PlayerMoveFSMInstance _moveInstance;
    [SerializeField] private PlayerBattleFMSInstance _battlerFSM;

    public override CharacterCharacteristicCard PersonalCCC => _personalCCC;
    private readonly PlayerCCC _personalCCC = new();
    public EntityOxygen EntityOxygen { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        EntityOxygen = new(this);
        EntityOxygen.OnOxygenDown += (float damage) => health.TakenDamage(damage);
    }

    public PlayerController GetPlayerController()
    {
        return (PlayerController)GetEntityController();
    }
    public PlayerMoveFSMInstance GetMoveInstance()
    {
        return _moveInstance;
    }
    public PlayerBattleFMSInstance GetBattleFSM() => _battlerFSM;

    public Transform GetViewPort() => _viewDirection;

    protected override void OnDeath()
    {
        _moveInstance.EntityDead();
        _battlerFSM.enabled = false;

        base.OnDeath();
    }
}
