using Assets.Scripts.CraftSystem;
using Assets.Scripts.UI.Scroll;
using UnityEngine;

public class WorkBenchWindow : MonoBehaviour
{
    [SerializeField] Transform _blueprintTable;
    [SerializeField] BlueprintDescriptor _descriptor;

    [SerializeField] private BlueprintPlate _blueprintPlate;
    [SerializeField] private ScrollRect _scrollRect;

    public void AddBlueprint(Blueprint blueprint)
    {
        BlueprintPlate blueprintPlate = Instantiate(_blueprintPlate, _blueprintTable);
        blueprintPlate.SetBlueprint(blueprint, () => 
            {
                _descriptor.SetBlueprint(blueprint);
                _descriptor.gameObject.SetActive(true);
            }
        );
        _scrollRect.CalculateRatio();
    }

    public void Close()
    {
        _descriptor.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
