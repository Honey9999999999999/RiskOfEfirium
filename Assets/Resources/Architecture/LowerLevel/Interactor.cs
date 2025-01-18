using System;

namespace Architecture
{
    public abstract class Interactor
    {
        public event Action OnInitialized;
        public bool IsInitialized { get; private set; }

        public virtual void OnCreate() { }
        public virtual void Initialize() { OnInitialized?.Invoke(); IsInitialized = true; }
        public virtual void OnStart() { }
    }
}
