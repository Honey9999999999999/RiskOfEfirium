using System;
using System.Collections;
using CoroutineManager;

namespace Architecture
{
    public abstract class GameBase<TSceneManager> where TSceneManager : SceneManagerBase, new()
    {
        public static event Action OnGameInitialized;
        public static TSceneManager sceneManager { get; private set; }

        public static void Run()
        {
            sceneManager = new TSceneManager();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            sceneManager.InitSceneConfigMap();
            yield return sceneManager.LoadCurrentSceneAsync();
            OnGameInitialized?.Invoke();
        }

        public static TType GetRepository<TType>() where TType : Repositories
        {
            return sceneManager.GetRepository<TType>();
        }
        public static TType GetInteractor<TType>() where TType : Interactor
        {
            return sceneManager.GetInteractor<TType>();
        }
    }
}
