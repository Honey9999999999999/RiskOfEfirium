using System;

namespace Architecture
{
    public abstract class Interactor
    {
        public static event Action OnInitialized;

        public virtual void OnCreate() { }
        public virtual void Initialize() { OnInitialized?.Invoke(); }
        public virtual void OnStart() { }
    }
}
