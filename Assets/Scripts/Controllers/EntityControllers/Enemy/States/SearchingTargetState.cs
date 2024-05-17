using Assets.Scripts.Controllers.EntityControllers.Enemy;
using Assets.Scripts.Controllers.EntityControllers.Enemy.States;
using FSM;
using UnityEngine;

public class SearchingTargetState : EnemyState
{
    public SearchingTargetState(FinalStateMachine<EnemyState> stateMachine, Collider target) : base(stateMachine, target)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(_target != null)
        {
            _stateMachine.EnterIn<PursuitTarget>();

            return;
        }
        else
        {
            _targetPosition = Vector3.zero;
        }
    }
}
