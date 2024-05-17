using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class PlayerController : EntityController
    {
        public event Action OnCameraInput;

        [SerializeField] private Vector2 _verticalInput;
        [SerializeField] private Vector2 _horizontalInput;
        [SerializeField] private CameraController _cameraController;

        public override Vector2 moveInput { get => _moveInput; }

        public override bool isWalk { get => (_moveInput.x * _moveInput.x) + (_moveInput.y * _moveInput.y) > 0.01f; }

        public override Vector3 viewDirection => GetViewDirection();

        private Vector2 _moveInput => (_verticalInput + _horizontalInput).normalized;

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                OnCameraInput?.Invoke();
            }

            if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _verticalInput = new Vector2(0, 1);
                }
                else
                {
                    _verticalInput = new Vector2(0, -1);
                }                    
            }
            else
            {
                _verticalInput = new Vector2(0, 0);
            }

            if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    _horizontalInput = new Vector2(-1, 0);
                }
                else
                {
                    _horizontalInput = new Vector2(1, 0);
                }                    
            }
            else
            {
                _horizontalInput = new Vector2(0, 0);
            }
        }

        private Vector3 GetViewDirection()
        {
            Vector3 cameraDirection = _cameraController.transform.forward;
            Vector3 viewDirection = new Vector3(cameraDirection.x, 0, cameraDirection.z).normalized;
            _cameraController.transform.localEulerAngles = Vector3.zero;

            return viewDirection;
        }
    }
}
