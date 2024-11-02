using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class DropListsConfig
    {
        public abstract Dictionary<NamesOfEnemies, ControlRandomList<NamesOfDrop>> _dropListsMap { get; }
    }
}
