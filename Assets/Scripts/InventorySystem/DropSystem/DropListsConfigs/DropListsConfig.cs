using Assets.Scripts.Entities;
using Assets.Scripts.InventorySystem.Items;
using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem.DropSystem.DropListsConfigs
{
    public abstract class DropListsConfig
    {
        public abstract Dictionary<NamesOfEnemies, ControlRandomList<NamesOfDrop>> _dropListsMap { get; }        
    }
}
