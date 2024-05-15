using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    [Serializable]
    public abstract class EntityController : MonoBehaviour
    {
        public abstract System.Numerics.Vector2 moveInput { get; }

        public abstract bool isWalk { get; }
    }
}
