using Assets.Scripts.Entities;
using Assets.Scripts.Tools;
using System.Collections.Generic;

namespace Assets.Scripts.InventorySystem
{
    public class DropListsSimpleConfig : DropListsConfig
    {
        public override Dictionary<NamesOfEnemies, ControlRandomList<NamesOfDrop>> _dropListsMap
        {
            get => new()
            {
                [NamesOfEnemies.Blob] = new()
                {
                    { 1, NamesOfDrop.AlienResources }
                }
            };
        }
    }
}
