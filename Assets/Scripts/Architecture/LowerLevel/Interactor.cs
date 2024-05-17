using System;

namespace Architecture
{
    public abstract class Interactor
    {
        public static event Action OnInitialized;
        public static bool isInitialized;

        public virtual void OnCreate() { }
        public virtual void Initialize() { OnInitialized?.Invoke(); isInitialized = true; }
        public virtual void OnStart() { }
    }
}
