using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace EntityControllers
{
    public class EnemyState : IState
    {
        protected FinalStateMachine<EnemyState> stateMachine;
        protected LivingEntity entity;
        protected ShellValue<Transform> target;

        public EnemyState(FinalStateMachine<EnemyState> stateMachine, LivingEntity entity, ShellValue<Transform> target) : base()
        {
            this.stateMachine = stateMachine;
            this.entity = entity;
            this.target = target;
        }

        public virtual void Enter() { }

        public virtual void Exit() { }

        public virtual void Update() { }

        protected bool IsSeeTarget()
        {
            if (target.value == null)
            {
                return false;
            }

            Vector3 direction = target.value.position - entity.transform.position;

            return Physics.Raycast(entity.transform.position, direction, out RaycastHit hitInfo, 99, (1 << 8) | (1 << 9) | (1 << 10), QueryTriggerInteraction.Ignore)
                && hitInfo.transform.TryGetComponent(out Player _);
        }
    }
}
