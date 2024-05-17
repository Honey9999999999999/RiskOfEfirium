using Assets.Scripts.Controllers.EntityControllers;
using Assets.Scripts.Entities;
using FSM;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField] protected Transform _viewDirection;

    public Transform GetViewPort() => _viewDirection;
}
