using Architecture;
using UI.Cursor.Configs;

namespace UI.Cursor
{
    public class CursorInteractor : Interactor
    {
        public Cursor cursor { get; private set; }

        public override void Initialize()
        {
            base.Initialize();

            cursor.SetMode(CursorMode.Standart);
        }

        public override void OnCreate()
        {
            base.OnCreate();

            cursor = new(new CursorSimpleConfig());
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
