using UnityEngine;

namespace Assets.Scripts.CraftSystem
{
    public class CraftWindow : MonoBehaviour
    {
        [SerializeField] private WorkBenchWindow _workBenchArmory;
        [SerializeField] private WorkBenchWindow _workBenchEngineer;
        [SerializeField] private WorkBenchWindow _workBenchMedical;

        public void AddBlueprint(Blueprint blueprint)
        {
            WorkBenchWindow workBench = blueprint.WorkBenchType switch
            {
                WorkBenchType.Armory => _workBenchArmory,
                WorkBenchType.Medical => _workBenchArmory,
                WorkBenchType.Engineer => _workBenchArmory,
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
        }

        public void CloseWindow()
        {
            _workBenchArmory.Close();
            //_workBenchEngineer.Close();
            //_workBenchMedical.Close();
        }
    }
}
