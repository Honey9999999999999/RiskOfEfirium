using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    [Serializable]
    public abstract class EntityController : MonoBehaviour
    {
        public abstract event Action OnCameraInput;
        public abstract Vector2 CameraControlInput { get; }
        public abstract Vector2 moveInput { get; }

        public abstract bool isWalk { get; }
    }
}
