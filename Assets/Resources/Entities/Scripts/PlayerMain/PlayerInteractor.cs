using System;
using System.Collections.Generic;
using Architecture;
using Assets.Scripts.CraftSystem;
using Assets.Scripts.InventorySystem;
using UnityEngine;

public class PlayerInteractor : Interactor
{
    public event Action<Blueprint> OnBlueprintAdded;
    public event Action OnMenuOpened;

    private const string PLAYER_PATH = "Entities/Prefabs/Player/Player";
    private Player player;
    private List<Blueprint> blueprints;
    private bool menuMode;

    public Player Player => player;
    public List<Blueprint> Blueprints => blueprints;
    public bool MenuMode
    {
        get { return menuMode; }
        set
        {
            menuMode = value;

            if (value)
                OnMenuOpened?.Invoke();
        }
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        GameObject playerObj = ResourceLoader.Load<GameObject>(PLAYER_PATH);
        playerObj.transform.position = new Vector3(0, 1, 0);

        if (!playerObj.TryGetComponent(out player))
        {
            throw new Exception("playerObj has't script \"Player\"");
        }
    }

    public override void OnStart()
    {
        base.OnStart();

        blueprints = new();

        List<Blueprint> blueprintsList = Game.GetInteractor<CraftSystemInteractor>().BlueprintsMap.GetBlueprints();

        foreach (var blueprint in blueprintsList)
        {
            if (blueprint.Info.Tier == Tier.Uncommon)
            {
                blueprints.Add(blueprint);
            }
        }
    }

    public void AddBlueprint(Blueprint blueprint)
    {
        if (Blueprints.Contains(blueprint)) return;

        Blueprints.Add(blueprint);
        OnBlueprintAdded?.Invoke(blueprint);
    }
}
