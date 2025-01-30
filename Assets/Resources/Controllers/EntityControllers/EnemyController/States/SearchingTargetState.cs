using System;
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
        public event Action<Vector3> OnExplore;

        private const float INTERVAL_SEARCHING = 5;
        private const float RADIUS_SEARCHING = 5;

        private readonly Timer timer;

        public SearchingTargetState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target) : base(stateMachine, entity, target)
        {
            timer = new();
            timer.OnStoped += ChoiseTargetPosition;
            TargetPosition = entity.transform.position;
        }

        public override void Enter()
        {
            base.Enter();

            StartSearchTimer();
        }

        public override void Exit()
        {
            base.Exit();

            timer.Reset();
        }

        public override void Update()
        {
            base.Update();

            if (IsSeeTarget())
            {
                stateMachine.EnterIn<PursuitTargetState>();

                return;
            }

            if (!timer.IsStarted)
            {
                StartSearchTimer();
            }
        }


        private void StartSearchTimer()
        {
            timer.Start(UnityEngine.Random.Range(1, INTERVAL_SEARCHING));
        }
        private void ChoiseTargetPosition()
        {
            OnExplore.Invoke(entity.transform.position
                + new Vector3(
                    UnityEngine.Random.Range(-RADIUS_SEARCHING, RADIUS_SEARCHING),
                    0,
                    UnityEngine.Random.Range(-RADIUS_SEARCHING, RADIUS_SEARCHING)
                )
            );
        }
    }
}