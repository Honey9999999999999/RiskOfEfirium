using Assets.Scripts.Controllers.EntityControllers.Enemy;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Controllers.EntityControllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemyController : EntityController
    {
        [SerializeField] private EnemyFSMInstance _fSMInstance;

        private Vector2 _moveInput;

        public override Vector3 viewDirection => Vector3.forward;
        public override Vector2 moveInput => _moveInput;
        public override bool isWalk => IsCurrentPosition();
        public bool isTarget => _fSMInstance.isTarget;

        private void Update()
        {
            if (_fSMInstance.isTarget)
            {
                _moveInput = new Vector2(0, 1);
            }
            else
            {
                _moveInput = Vector2.zero;
            }
        }

        public bool TryGetTarget(out Transform target)
        {
            if (_fSMInstance.isTarget)
            {
                target = GetTarget();
                return true;
            }

            target = null;
            return false;
            
        }
        public Transform GetTarget() => _fSMInstance.GetTarget();

        private bool IsCurrentPosition()
        {
            Vector3 vector = _fSMInstance.GetTargetPosition() - transform.position;
            return (vector.x * vector.x + vector.y * vector.y) < 0.01f;
        }
    }
}
