using System;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static event Action OnAttackInput;
        public static event Action<float> OnScrollInput;

        public static event Action OnCameraFirstInput;
        public static event Action OnCameraInput;

        public static event Action OnTabInput;
        public static event Action OnEscInput;
        public static event Action OnInteractionButtonInput;

        public static event Action OnMoveInput;        

        private float xMove;
        private float yMove;

        public static InputHandler Instance { get; private set; }

        public static Vector2 MoveDirection => new Vector2(Instance.xMove, Instance.yMove).normalized;

        public static bool IsMoveDeadZone { get => (MoveDirection.x * MoveDirection.x)
                                                 + (MoveDirection.y * MoveDirection.y) < 0.01f; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
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
            }

            if (Input.mouseScrollDelta.y != 0)
            {
                OnScrollInput?.Invoke(Input.mouseScrollDelta.y);
            }
        }
        private void KeyBoardChecks()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                OnTabInput?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnInteractionButtonInput?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnEscInput?.Invoke();
            }

            if (Input.GetKey(KeyCode.W) ^ Input.GetKey(KeyCode.S))
            {
                if (Input.GetKey(KeyCode.W))
                {
                    yMove = 1;
                }
                else
                {
                    yMove = -1;
                }
                OnMoveInput?.Invoke();
            }
            else
            {
                yMove = 0;
            }

            if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.A))
                {
                    xMove = -1;
                }
                else
                {
                    xMove = 1;
                }
                OnMoveInput?.Invoke();
            }
            else
            {
                xMove = 0;
            }
        }
    }
}
