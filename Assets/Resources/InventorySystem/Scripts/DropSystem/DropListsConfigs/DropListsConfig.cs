using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public abstract class DropListsConfig
    {
        protected abstract Dictionary<NamesOfEnemies, ControlRandomList<ItemNames>> _dropListsMap { get; }

        public ItemNames GetDropName(NamesOfEnemies enemyName)
        {
            return _dropListsMap[enemyName].GetValue();
        }
    }
}
