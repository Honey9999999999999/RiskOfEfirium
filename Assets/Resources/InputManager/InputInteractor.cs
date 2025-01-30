using Architecture;
using UnityEngine;

namespace Assets.Scripts.InputManager
{
    public class InputInteractor : Interactor
    {
        public InputHandler input { get; private set; }
        public override void Initialize()
        {
            base.Initialize();

            input = InputHandler.Instance;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            new GameObject("InputHandler").AddComponent<InputHandler>();
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
