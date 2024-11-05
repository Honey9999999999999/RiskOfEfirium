using Assets.Scripts.Bank;
using Assets.Scripts.CraftSystem;
using Assets.Scripts.InputManager;
using Assets.Scripts.InventorySystem;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.Map;
using Assets.Scripts.MapDrawer;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using UICursor;

namespace Architecture
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SCENE_NAME = "TestScene";
        public override string sceneName => SCENE_NAME;

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            _interactorsMap = new Dictionary<Type, Interactor>();

            CreateInteractor<InputInteractor>();
            CreateInteractor<LootInteractor>();

            CreateInteractor<UICanvasIntaractor>();
            CreateInteractor<CursorInteractor>();

            CreateInteractor<LabyrinthInteractor>();
            CreateInteractor<MapInteractor>();
            CreateInteractor<MiniMapInteractor>();
            CreateInteractor<NavMeshInteractor>();

            CreateInteractor<PlayerInteractor>();
            CreateInteractor<InventorySystemInteractor>();
            CreateInteractor<CraftSystemInteractor>();
            CreateInteractor<CameraInteractor>();

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
