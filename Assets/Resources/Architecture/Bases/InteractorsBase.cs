using System;
using System.Collections.Generic;

namespace Architecture
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> _interactorsMap;

        private SceneConfig _sceneConfig;

        public InteractorsBase(SceneConfig sceneConfig)
        {
            _sceneConfig = sceneConfig;
            _interactorsMap = _sceneConfig.CreateAllInteractors();
        }

        public void SendOnCreateToAllInteractors()
        {
            foreach (var key in _interactorsMap.Keys)
            {
                _interactorsMap[key].OnCreate();
            }
        }
        public void SendInitializeToAllInteractors()
        {
            foreach (var key in _interactorsMap.Keys)
            {
                _interactorsMap[key].Initialize();
            }
        }
        public void SendOnStartToAllInteractors()
        {
            foreach (var key in _interactorsMap.Keys)
            {
                _interactorsMap[key].OnStart();
            }
        }

        public TType GetInteractor<TType>() where TType : Interactor
        {
            return (TType)_interactorsMap[typeof(TType)];
        }
    }
}
