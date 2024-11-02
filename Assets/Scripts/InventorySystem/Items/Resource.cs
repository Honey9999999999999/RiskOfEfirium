using Assets.Scripts.Tools;
using System;
namespace Assets.Scripts.InventorySystem
{
    public sealed class Resource : ResourceBase<Resource>
    {
        public NamesOfDrop Name { get; }
        public Resource(NamesOfDrop name) : base(0, 256) 
        {
            Name = name;
        }
    }
}
