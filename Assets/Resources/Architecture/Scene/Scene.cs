using System.Collections;
using CoroutineManager;
using UnityEngine;

namespace Architecture
{
    public class Scene
    {
        private RepositoriesBase _repositoriesBase;
        private InteractorsBase _interactorsBase;

        private SceneConfig _sceneConfig;

        public Scene(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;

            _repositoriesBase = new RepositoriesBase(_sceneConfig);
            _interactorsBase = new InteractorsBase(_sceneConfig);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            _repositoriesBase.SendOnCreateToAllRepositories();
            _interactorsBase.SendOnCreateToAllInteractors();

            yield return null;

            _repositoriesBase.SendInitializeToAllRepositories();
            _interactorsBase.SendInitializeToAllInteractors();

            yield return null;

            _repositoriesBase.SendOnStartToAllRepositories();
            _interactorsBase.SendOnStartToAllInteractors();
        }

        public TType GetRepository<TType>() where TType : Repositories
        {
            return _repositoriesBase.GetRepository<TType>();
        }
        public TType GetInteractor<TType>() where TType : Interactor
        {
            return _interactorsBase.GetInteractor<TType>();
        }
    }
}
