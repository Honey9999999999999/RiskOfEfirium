using Assets.Scripts.CraftSystem;
using Assets.Scripts.InventorySystem;
using System.Collections.Generic;

public abstract class Blueprint
{
    public abstract WorkBenchType WorkBenchType { get; }
    public abstract NamesOfDrop ItemName { get; }
    public abstract Dictionary<NamesOfDrop, int> Components { get; }
}
