using Assets.Scripts.Entities;
using MoveFSM;
using UnityEngine;

public class Player : LivingEntity
{
    [SerializeField] protected Transform _viewDirection;

    private void Awake()
    {
        _mover.OnInitialized += () => _mover.GetState<WalkState>().OnWalk += ViewOnDirection;
    }

    public Transform GetViewPort() => _viewDirection;
    protected void ViewOnDirection()
    {
        transform.eulerAngles += _viewDirection.localEulerAngles;
        _viewDirection.localEulerAngles -= _viewDirection.localEulerAngles;
    }
}
