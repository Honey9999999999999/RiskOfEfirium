using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField] private Transform _viewDirection;

    public PlayerController GetPlayerController()
    {
        return (PlayerController)GetEntityController();
    }

    public Transform GetViewPort() => _viewDirection;

    protected override void OnDeath()
    {
        base.OnDeath();
    }
}
