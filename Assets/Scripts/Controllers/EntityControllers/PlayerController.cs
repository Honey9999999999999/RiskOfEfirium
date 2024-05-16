using System;
using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class PlayerController : EntityController
    {
        public override event Action OnCameraInput;

        [SerializeField] private Vector2 _verticalInput;
        [SerializeField] private Vector2 _horizontalInput;

        public override Vector2 moveInput { get => _moveInput; }

        public override bool isWalk { get => (_moveInput.x * _moveInput.x) + (_moveInput.y * _moveInput.y) > 0.01f; }

        public override Vector2 CameraControlInput => GetCameraInput();
        private Vector3 _cameraPositionOld;

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

        private Vector3 GetCameraInput()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _cameraPositionOld = Input.mousePosition;
            }
            if (Input.GetMouseButton(1))
            {
                Vector3 mousePositionDelta = _cameraPositionOld - Input.mousePosition;
                _cameraPositionOld = Input.mousePosition;
                return mousePositionDelta;
            }
            else
            {
                _cameraPositionOld = Vector3.zero;
                return Vector3.zero;
            }
        }
    }
}
