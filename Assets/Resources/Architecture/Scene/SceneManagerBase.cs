using System;
using System.Collections;
using System.Collections.Generic;
using CoroutineManager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture
{
    public abstract class SceneManagerBase
    {
        public event Action<Scene> OnSceneStartLoading;
        public event Action<Scene> OnSceneLoaded;

        public Scene currentScene { get; private set; }
        public bool isLoading { get; private set; }

        protected Dictionary<string, SceneConfig> _sceneConfigMap;

        public SceneManagerBase()
        {
            _sceneConfigMap = new Dictionary<string, SceneConfig>();
        }

        public abstract void InitSceneConfigMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if (isLoading)
            {
                throw new Exception("Scene is loading now");
            }

            var config = _sceneConfigMap[SceneManager.GetActiveScene().name];

            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
        }
        private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            OnSceneStartLoading?.Invoke(currentScene);

            yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

            isLoading = false;
            OnSceneLoaded?.Invoke(currentScene);
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (isLoading)
            {
                throw new Exception("Scene is loading now");
            }

            var config = _sceneConfigMap[sceneName];

            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }
        private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
        {
            isLoading = true;
            OnSceneStartLoading?.Invoke(currentScene);

            yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

            isLoading = false;
            OnSceneLoaded?.Invoke(currentScene);
        }

        private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
            async.allowSceneActivation = false;

            while (async.progress < 0.9f)
            {
                yield return null;
            }

            async.allowSceneActivation = true;
        }

        private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
        {
            currentScene = new Scene(sceneConfig);
            yield return currentScene.InitializeAsync();
        }

        public TType GetRepository<TType>() where TType : Repositories
        {
            return currentScene.GetRepository<TType>();
        }
        public TType GetInteractor<TType>() where TType : Interactor
        {
            return currentScene.GetInteractor<TType>();
        }
    }
}
