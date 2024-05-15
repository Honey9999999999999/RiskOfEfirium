using UnityEngine;

namespace Assets.Scripts.Controllers.EntityControllers
{
    public class PlayerController : EntityController
    {
        private System.Numerics.Vector2 _verticalInput;
        private System.Numerics.Vector2 _horizontalInput;

        public override System.Numerics.Vector2 moveInput { get => _moveInput; }

        public override bool isWalk { get => _moveInput.LengthSquared() > 0.01f; }

        //System.Numerics.Vector2 moveInput { get => _moveInput; }
        //bool isWalk { get => _moveInput.LengthSquared() > 0.01f; }

        private System.Numerics.Vector2 _moveInput => System.Numerics.Vector2.Normalize(_verticalInput + _horizontalInput);

        private void Update()
        {
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    _verticalInput = new System.Numerics.Vector2(0, 1);
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    _verticalInput = new System.Numerics.Vector2(0, -1);
                }
                else
                {
                    _verticalInput = new System.Numerics.Vector2(0, 0);
                }

                if (Input.GetKey(KeyCode.A))
                {
                    _horizontalInput = new System.Numerics.Vector2(-1, 0);
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    _horizontalInput = new System.Numerics.Vector2(1, 0);
                }
                else
                {
                    _horizontalInput = new System.Numerics.Vector2(0, 0);
                }
            }
        }
    }
}
