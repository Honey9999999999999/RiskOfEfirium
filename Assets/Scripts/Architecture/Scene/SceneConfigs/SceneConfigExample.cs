using Assets.Scripts.Bank;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.MapDrawer;
using System;
using System.Collections.Generic;

namespace Architecture
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SCENE_NAME = "TestScene";
        public override string sceneName => SCENE_NAME;

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            _interactorsMap = new Dictionary<Type, Interactor>();

            CreateInteractor<BankInteractor>();
            CreateInteractor<LabyrinthInteractor>();
            CreateInteractor<MiniMapInteractor>();
            CreateInteractor<PlayerPositionInteractor>();

            return _interactorsMap;
        }

        public override Dictionary<Type, Repositories> CreateAllRepositories()
        {
            _repositoriesMap = new Dictionary<Type, Repositories>();

            CreateRepositories<BankRepositories>();

            return _repositoriesMap;
        }
    }
}
