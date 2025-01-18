using Architecture;
using Assets.Scripts.CraftSystem;
using Assets.Scripts.CraftSystem.UI;
using Assets.Scripts.InventorySystem;
using System.Collections.Generic;
using UnityEngine;

public class WorkBenchWindow : MonoBehaviour
{
    public static Blueprint currentBlueprint;

    public WorkBenchType type;

    [SerializeField] private Transform _blueprintTable;
    [SerializeField] private BlueprintDescriptor _descriptor;
    [SerializeField] private TableProgressBars _tableProgressBars;
    [SerializeField] private LightsControl _lightsControl;

    [SerializeField] private BlueprintPlate _blueprintPlate;


    public void FillTable()
    {
        List<Blueprint> blueprints = Game.GetInteractor<PlayerInteractor>().Blueprints;

        Clear();

        foreach (var blueprint in blueprints)
        {
            if (blueprint.WorkBenchType == type)
            {
                AddBlueprint(blueprint);
            }
        }
    }

    public void FillTable(Tier tier)
    {
        List<Blueprint> blueprints = Game.GetInteractor<PlayerInteractor>().Blueprints;

        Clear();

        foreach (var blueprint in blueprints)
        {
            if(blueprint.WorkBenchType == type)
            {
                if(blueprint.Info.Tier == tier)
                {
                    AddBlueprint(blueprint);
                }
            }
        }
    }

    public void Clear()
    {
        for (int i = 0; i < _blueprintTable.childCount; i++)
        {
            Destroy(_blueprintTable.GetChild(i).gameObject);
        }

        _descriptor.Crear();
        _lightsControl.SetNeutral();
    }


    public void AddBlueprint(Blueprint blueprint)
    {
        BlueprintPlate blueprintPlate = Instantiate(_blueprintPlate, _blueprintTable);
        blueprintPlate.SetBlueprint(blueprint, () =>
        {
            currentBlueprint = blueprint;

            _descriptor.SetBlueprint();
            _descriptor.gameObject.SetActive(true);
            _tableProgressBars.SetBlueprint();
            _lightsControl.SetState();
        }
        );
    }


    public void OpenTierCommon() => FillTable(Tier.Common);
    public void OpenTierUncommon() => FillTable(Tier.Uncommon);
    public void OpenTierRare() => FillTable(Tier.Rare);
    public void OpenTierLegendary() => FillTable(Tier.Legendary);
    

    public void Close()
    {
        currentBlueprint = null;
        gameObject.SetActive(false);
        _descriptor.Crear();
        _tableProgressBars.Clear();
    }
}
