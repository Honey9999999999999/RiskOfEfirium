using System;
using System.Collections.Generic;

namespace Architecture
{
    public abstract class SceneConfig
    {
        public abstract string sceneName { get; }

        protected Dictionary<Type, Repositories> _repositoriesMap;
        protected Dictionary<Type, Interactor> _interactorsMap;

        public abstract Dictionary<Type, Repositories> CreateAllRepositories();
        public abstract Dictionary<Type, Interactor> CreateAllInteractors();

        protected void CreateRepositories<TType>() where TType : Repositories, new()
        {
            _repositoriesMap[typeof(TType)] = new TType();
        }
        protected void CreateInteractor<TType>() where TType : Interactor, new()
        {
            _interactorsMap[typeof(TType)] = new TType();
        }
    }
}
