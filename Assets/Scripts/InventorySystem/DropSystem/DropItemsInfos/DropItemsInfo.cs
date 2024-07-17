using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventorySystem.DropSystem
{
    public abstract class DropItemsInfo
    {
        public abstract Dictionary<NamesOfDrop, string> _dropMap { get; }
    }
}
