using Architecture;
using Assets.Scripts.Tools;

namespace Assets.Scripts.CraftSystem
{
    public class CraftSystemInteractor : Interactor
    {
        public ItemCreator Crafter { get; private set; }
        public CraftWindow CraftWindow { get; private set; }
        public BlueprintsMap BlueprintsMap { get; private set; }

        private const string PATH_TO_CRAFTWINDOW = "CraftSystem/Prefabs/UICraft";

        public override void OnCreate()
        {
            base.OnCreate();
            BlueprintsMap = new();
        }

        public override void Initialize()
        {
            base.Initialize();
            
            Crafter = new();
            CraftWindow = ResourceLoader.Load<CraftWindow>(PATH_TO_CRAFTWINDOW, Game.GetInteractor<PlayerUIInteractor>().UICanvas.transform);
        }

        public override void OnStart()
        {
            base.OnStart();
        }
    }
}
