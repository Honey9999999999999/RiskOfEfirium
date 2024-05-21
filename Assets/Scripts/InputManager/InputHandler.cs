using System;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static event Action OnAttackInput;
        public static event Action OnCameraFirstInput;
        public static event Action OnCameraInput;
        public static event Action OnTabInput;

        public static InputHandler instance { get; private set; }

        private float _xMove;
        private float _yMove;        

        public Vector2 moveVector => new Vector2(_xMove, _yMove).normalized;

        public bool isCameraRotate { get; private set; }
        public bool isMoveDeadZone { get => (moveVector.x * moveVector.x) + (moveVector.y * moveVector.y) < 0.01f; }

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            MouseChecks();
            KeyBoardChecks();
        }

        private void MouseChecks()
        {
            if (Input.GetMouseButton(0))
            {
                OnAttackInput?.Invoke();
            }

            if (Input.GetMouseButtonDown(1))
            {
                OnCameraFirstInput?.Invoke();
            }
            if (Input.GetMouseButton(1))
            {
                OnCameraInput?.Invoke();
                isCameraRotate = true;
            }
            else
            {
                isCameraRotate = false;
            }
        }
        private void KeyBoardChecks()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OnTabInput?.Invoke();
            }

            if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _yMove = 1;
                }
                else
                {
                    _yMove = -1;
                }
            }
            else
            {
                _yMove = 0;
            }

            if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    _xMove = -1;
                }
                else
                {
                    _xMove = 1;
                }
            }
            else
            {
                _xMove = 0;
            }
        }
    }
}
