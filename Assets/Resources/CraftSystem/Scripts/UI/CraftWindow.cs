using Assets.Scripts.CraftSystem.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.CraftSystem
{
    public class CraftWindow : MonoBehaviour
    {
        [SerializeField] private List<WorkBenchWindow> workBenchesList;
        [SerializeField] private BasesResourcesTable _resourcesTable;

        public void OpenWindow(WorkBenchType type)
        {
            foreach (var workBench in workBenchesList)
            {
                if(workBench.type == type)
                {
                    workBench.FillTable();
                    workBench.gameObject.SetActive(true);
                    _resourcesTable.OpenTable();

                    return;
                }
            }           
        }

        public void CloseWindow()
        {
            _resourcesTable.CloseTable();

            foreach (var workBench in workBenchesList)
            {
                workBench.Close();
            }
        }
    }
}
