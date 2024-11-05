using Assets.Scripts.Tools;
using Interfaces;

namespace Assets.Scripts.InventorySystem
{
    public abstract class Item : ResourceBase<Item>, IEffecter
    {
        public abstract NamesOfDrop Name { get; }

        public abstract void Effect();
        public abstract void ReverseEffect();
    }
}
