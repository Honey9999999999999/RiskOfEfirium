using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class DropListsConfig
    {
        protected abstract Dictionary<NamesOfEnemies, ControlRandomList<NamesOfDrop>> _dropListsMap { get; }

        public NamesOfDrop GetDropName(NamesOfEnemies enemyName)
        {
            return _dropListsMap[enemyName].GetValue();
        }
    }
}
