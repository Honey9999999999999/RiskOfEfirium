using Architecture;
using Assets.Scripts.InventorySystem;
using UnityEngine;

public class PlayerUIInteractor : Interactor
{
    private const string CANVAS_PATH = "PlayerUI/Prefabs/UICanvas";
    private const string HEALTHBAR_PATH = "PlayerUI/Prefabs/PlayerHealthBar";
    private const string OXYGENBAR_PATH = "PlayerUI/Prefabs/OxygenBar";
    private const string MINIMAP_PATH = "PlayerUI/Prefabs/MiniMap";
    private const string INVENTORY_PATH = "PlayerUI/Prefabs/Inventory";

    public Canvas UICanvas { get; private set; }
    public GameObject HealthBar { get; private set; }
    public GameObject OxygenBar { get; private set; }
    public GameObject MiniMap { get; private set; }
    public UIInventory Inventory { get; private set; }

    public override void OnCreate()
    {
        base.OnCreate();

        UICanvas = ResourceLoader.Load<Canvas>(CANVAS_PATH);
        HealthBar = ResourceLoader.Load<GameObject>(HEALTHBAR_PATH, UICanvas.transform);
        OxygenBar = ResourceLoader.Load<GameObject>(OXYGENBAR_PATH, UICanvas.transform);
        MiniMap = ResourceLoader.Load<GameObject>(MINIMAP_PATH, UICanvas.transform);
        Inventory = ResourceLoader.Load<UIInventory>(INVENTORY_PATH, UICanvas.transform);
    }

    public override void Initialize()
    {
        base.Initialize();

        Item.OnResourceAmountChanged += Inventory.ChangeCountValue;
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
