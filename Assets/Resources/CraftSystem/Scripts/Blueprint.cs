using System.Collections.Generic;
using Assets.Scripts.CraftSystem;
using Assets.Scripts.InventorySystem;

public class Blueprint
{
    public WorkBenchType WorkBenchType { get; }
    public ItemInfo Info { get; }
    public Dictionary<ItemNames, int> Components { get; }

    public Blueprint(WorkBenchType type, ItemInfo info, Dictionary<ItemNames, int> componentsMap)
    {
        WorkBenchType = type;
        Info = info;
        Components = componentsMap;
    }
}
