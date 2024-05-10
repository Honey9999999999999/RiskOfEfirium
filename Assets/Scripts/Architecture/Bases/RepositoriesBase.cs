using System;
using System.Collections.Generic;

namespace Architecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repositories> _repositoriesMap;

        private SceneConfig _sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
            _repositoriesMap = _sceneConfig.CreateAllRepositories();
        }

        public void SendOnCreateToAllRepositories()
        {
            foreach (var key in _repositoriesMap.Keys)
            {
                _repositoriesMap[key].OnCreate();
            }
        }
        public void SendInitializeToAllRepositories()
        {
            foreach (var key in _repositoriesMap.Keys)
            {
                _repositoriesMap[key].Initialize();
            }
        }
        public void SendOnStartToAllRepositories()
        {
            foreach (var key in _repositoriesMap.Keys)
            {
                _repositoriesMap[key].OnStart();
            }
        }

        public TType GetRepository<TType>() where TType : Repositories
        {
            return (TType)_repositoriesMap[typeof(TType)];
        }
    }
}
