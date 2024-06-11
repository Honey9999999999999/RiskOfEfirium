using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using EntityControllers;
using FSM;
using MyTimer;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class SearchingTargetState : EnemyState
    {
        private const float INTERVAL_SEARCHING = 5;
        private const float RADIUS_SEARCHING = 5;

        private Timer _timer;

        public SearchingTargetState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target) : base(stateMachine, entity, target)
        {
            _timer = new();
            _timer.OnStoped += ChoiseTargetPosition;
            _targetPosition = entity.transform.position;
        }

        public override void Enter()
        {
            base.Enter();

            StartSearchTimer();
        }

        public override void Exit()
        {
            base.Exit();

            _timer.Reset();
        }

        public override void Update()
        {
            base.Update();

            if (_target.value != null)
            {
                _stateMachine.EnterIn<PursuitTarget>();

                return;
            }

            if (!_timer.isStarted)
            {
                StartSearchTimer();
            }
        }


        private void StartSearchTimer()
        {
            _timer.Start(Random.Range(INTERVAL_SEARCHING, INTERVAL_SEARCHING + 2));
        }
        private void ChoiseTargetPosition()
        {
            _targetPosition = _entity.transform.position + new Vector3(Random.Range(-RADIUS_SEARCHING, RADIUS_SEARCHING), 0, Random.Range(-RADIUS_SEARCHING, RADIUS_SEARCHING));
        }
    }
}