using System.Collections.Generic;
using Assets.Scripts.Entities;
using Assets.Scripts.Tools;

namespace Assets.Scripts.InventorySystem
{
    public class DropListsSimpleConfig : DropListsConfig
    {
        protected override Dictionary<NamesOfEnemies, ControlRandomList<ItemNames>> _dropListsMap
        {
            get => new()
            {
                [NamesOfEnemies.Blob] = new()
                {
                    { 1, ItemNames.AlienResources }
                }
            };
        }
    }
}
