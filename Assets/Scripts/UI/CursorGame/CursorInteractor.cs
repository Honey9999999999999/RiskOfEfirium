using Architecture;
using UnityEngine;
namespace UICursor
{
    public class CursorInteractor : Interactor
    {
        public CursorFSMExample cursor { get; private set; }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnCreate()
        {
            base.OnCreate();

            cursor = new GameObject("CursorFSM").AddComponent<CursorFSMExample>();
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
