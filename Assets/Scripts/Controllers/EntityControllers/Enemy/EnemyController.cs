using UnityEngine;

namespace EntityControllers
{
    [RequireComponent(typeof(SphereCollider))]
    public class EnemyController : EntityController
    {
        [SerializeField] private EnemyFSMInstance _fSMInstance;

        public override bool isWalk => !IsCurrentPosition();
        public bool isTarget => _fSMInstance.isTarget;
        public Transform target => _fSMInstance.GetTarget();
        public Vector3 targetPosition => _fSMInstance.GetTargetPosition();

        public bool TryGetTarget(out Transform target)
        {
            if (_fSMInstance.isTarget)
            {
                target = this.target;
                return true;
            }

            target = null;
            return false;            
        }

        private bool IsCurrentPosition()
        {
            Vector3 vector = targetPosition - transform.position;
            return (vector.x * vector.x + vector.y * vector.y) < 0.1f;
        }
    }
}
