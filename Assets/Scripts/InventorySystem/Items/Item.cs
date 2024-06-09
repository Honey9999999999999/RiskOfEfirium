using Assets.Scripts.Tools;
using Interfaces;

namespace Assets.Scripts.InventorySystem.Items
{
    public abstract class Item : Resource<Item>, IEffecter
    {
        public abstract void Effect();
        public abstract void ReverseEffect();
    }
}
