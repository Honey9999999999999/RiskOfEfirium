using Architecture;
using Assets.Scripts.Tools;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class UICanvasIntaractor : Interactor
    {
        private const string CANVAS_PATH = "Prefabs/UI/UICanvas";

        public Canvas uiCanvas { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            uiCanvas = ResourceLoader.Load<Canvas>(CANVAS_PATH);
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
