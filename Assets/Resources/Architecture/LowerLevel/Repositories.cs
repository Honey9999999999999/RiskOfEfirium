namespace Architecture
{
    public abstract class Repositories
    {
        public abstract void OnCreate();
        public abstract void Initialize();
        public abstract void OnStart();
        public abstract void Save();
    }
}
