using Assets.Scripts.CraftSystem;
using Assets.Scripts.InventorySystem;
using System.Collections.Generic;

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
