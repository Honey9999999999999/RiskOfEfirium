using System.Collections.Generic;
using Architecture;
using Assets.Scripts.Map;
using UnityEngine;

public class ContainerPlace : MonoBehaviour
{
    public GameObject lockedContainer;
    public List<LootContainer> lootContainers = new();
    [Space]
    [Range(0, 1)]
    public float chance;

    private void Awake()
    {
        Game.GetInteractor<MapInteractor>().OnStarted += Generate;
    }

    private void Generate()
    {
        if(lootContainers.Count > 0)
        {
            if(Random.Range(0, 1f) >= chance)
            {
                Instantiate(lootContainers[Random.Range(0, lootContainers.Count)], transform);
            }
            else
            {
                if(lockedContainer != null)
                    Instantiate(lockedContainer, transform);
            }
        }
    }
}
