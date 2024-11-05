using Architecture;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.Tools;
using Assets.Scripts.UI;

namespace Assets.Scripts.CraftSystem
{
    public class CraftSystemInteractor : Interactor
    {
        public ItemCreator Crafter { get; private set; }
        public CraftWindow CraftWindow { get; private set; }

        private const string PATH_TO_CRAFTWINDOW = "Prefabs/CraftSystem/UI/UICraft";

        public override void Initialize()
        {
            base.Initialize();

            Crafter = new();
            CraftWindow = ResourceLoader.Load<CraftWindow>(PATH_TO_CRAFTWINDOW, Game.GetInteractor<UICanvasIntaractor>().uiCanvas.transform);
        }

        public override void OnStart()
        {
            base.OnStart();

            Inventory inventory = Game.GetInteractor<InventorySystemInteractor>().Inventory;

            inventory.OnBlueprintAdded += CraftWindow.AddBlueprint;

            foreach (Blueprint blueprint in inventory.Blueprints)
            {
                CraftWindow.AddBlueprint(blueprint);
            }            
        }
    }
}
