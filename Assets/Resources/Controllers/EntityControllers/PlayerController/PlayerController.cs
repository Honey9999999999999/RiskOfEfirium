using Assets.Scripts.InputManager;
using EntityControllers;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class PlayerController : EntityController
    {
        public Vector3 viewDirection => GetViewDirection();

        public override bool isWalk { get => !InputHandler.IsMoveDeadZone; }
        public bool IsBattle { get; private set; }

        public void Start()
        {
            InputHandler.OnTabInput += () => IsBattle = !IsBattle;
        }

        private Vector3 GetViewDirection()
        {
            Vector3 cameraDirection = CameraController.instance.transform.forward;
            Vector3 viewDirection = new Vector3(cameraDirection.x, 0, cameraDirection.z).normalized;
            CameraController.instance.transform.localEulerAngles = Vector3.zero;

            return viewDirection;
        }
    }
}
