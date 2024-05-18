using UnityEngine;

namespace EntityControllers
{
    public abstract class EntityController : MonoBehaviour
    {
        public abstract bool isWalk { get; }
    }
}
