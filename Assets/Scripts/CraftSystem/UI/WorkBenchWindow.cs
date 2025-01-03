using Assets.Scripts.CraftSystem;
using Assets.Scripts.CraftSystem.UI;
using UnityEngine;

public class WorkBenchWindow : MonoBehaviour
{
    public static Blueprint currentBlueprint;

    [SerializeField] Transform _blueprintTable;
    [SerializeField] BlueprintDescriptor _descriptor;
    [SerializeField] TableProgressBars _tableProgressBars;
    [SerializeField] LightsControl _lightsControl;

    [SerializeField] private BlueprintPlate _blueprintPlate;

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

    public void Close()
    {
        currentBlueprint = null;
        gameObject.SetActive(false);
        _lightsControl.SetNeutral();
        _descriptor.Crear();
        _tableProgressBars.Clear();
    }
}
