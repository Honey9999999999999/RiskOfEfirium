using Assets.Scripts.CraftSystem.UI;
using UnityEngine;

namespace Assets.Scripts.CraftSystem
{
    public class CraftWindow : MonoBehaviour
    {
        [SerializeField] private WorkBenchWindow _workBenchArmory;
        [SerializeField] private WorkBenchWindow _workBenchEngineer;
        [SerializeField] private WorkBenchWindow _workBenchMedical;

        [SerializeField] private BasesResourcesTable _resourcesTable;
        [SerializeField] private LightsControl lightsControl;

        public void AddBlueprint(Blueprint blueprint)
        {
            WorkBenchWindow workBench = blueprint.WorkBenchType switch
            {
                WorkBenchType.Armory => _workBenchArmory,
                WorkBenchType.Medical => _workBenchMedical,
                WorkBenchType.Engineer => _workBenchEngineer,
                _ => throw new System.Exception(),
            };

            workBench.AddBlueprint(blueprint);
        }

        public void OpenWindow(WorkBenchType type)
        {
            switch (type)
            {
                case WorkBenchType.Armory:
                    _workBenchArmory.gameObject.SetActive(true);
                    break;
                case WorkBenchType.Medical:
                    _workBenchMedical.gameObject.SetActive(true);
                    break;
                case WorkBenchType.Engineer:
                    _workBenchEngineer.gameObject.SetActive(true);
                    break;
                default:
                    throw new System.Exception();
            }

            _resourcesTable.OpenTable();
        }

        public void CloseWindow()
        {
            _resourcesTable.CloseTable();

            _workBenchArmory.Close();
            _workBenchEngineer.Close();
            _workBenchMedical.Close();
        }
    }
}
