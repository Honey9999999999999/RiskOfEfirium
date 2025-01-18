using Architecture;
using UnityEngine;
namespace UICursor
{
    public class CursorInteractor : Interactor
    {
        public CursorFSMExample Cursor { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void OnStart()
        {
            base.OnStart();

            Cursor = new GameObject("CursorFSM").AddComponent<CursorFSMExample>();
        }
    }
}
