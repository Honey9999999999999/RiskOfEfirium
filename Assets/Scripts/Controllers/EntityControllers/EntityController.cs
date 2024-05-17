using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    [Serializable]
    public abstract class EntityController : MonoBehaviour
    {
        public abstract Vector3 viewDirection { get; }
        public abstract Vector2 moveInput { get; }

        public abstract bool isWalk { get; }
    }
}
