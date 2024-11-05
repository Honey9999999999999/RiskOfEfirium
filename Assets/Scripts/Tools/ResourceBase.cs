using Assets.Scripts.InventorySystem;
using System;

namespace Assets.Scripts.Tools
{
    public abstract class ResourceBase<T> where T : ResourceBase<T>
    {
        public static event Action<T> OnResourceAmountChanged;
        public static event Action<T> OnResourceAdded;
        public static event Action<T> OnResourceTaked;

        private int _amount;

        public ResourceBase() : this(0, 64) { }
        public ResourceBase(int amount, int maxStack)
        {
            _amount = amount;
            this.maxStack = maxStack;
        }

        public int maxStack { get; }
        public int amount
        {
            get => _amount; set
            {
                value = Math.Clamp(value, 0, maxStack);

                if (_amount != value)
                {
                    int oldValue = _amount;
                    _amount = value;

                    if (value > oldValue)
                    {
                        OnResourceAdded?.Invoke((T)this);
                    }
                    else
                    {
                        OnResourceTaked?.Invoke((T)this);
                    }

                    OnResourceAmountChanged?.Invoke((T)this);
                }
            }
        }
    }
}
