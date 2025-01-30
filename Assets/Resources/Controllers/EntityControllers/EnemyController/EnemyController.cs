using UnityEngine;

namespace EntityControllers
{
    //[RequireComponent(typeof(SphereCollider))]
    //public class EnemyController : EntityController
    //{
    //    [SerializeField] private EnemyBattleFSMInstance _fSMInstance;

    //    public override bool isWalk => !IsCurrentPosition();
    //    public bool isTarget => _fSMInstance.isTarget;

    //    public Transform Target => _fSMInstance.GetTarget();
    //    public Vector3 TargetPosition => _fSMInstance.GetTargetPosition();

    //    public bool TryGetTarget(out Transform target)
    //    {
    //        if (_fSMInstance.isTarget)
    //        {
    //            target = Target;
    //            return true;
    //        }

    //        target = null;
    //        return false;
    //    }

    //    private bool IsCurrentPosition()
    //    {
    //        Vector3 vector = TargetPosition - transform.position;
    //        return (vector.x * vector.x + vector.y * vector.y) < 0.1f;
    //    }
    //}
}
