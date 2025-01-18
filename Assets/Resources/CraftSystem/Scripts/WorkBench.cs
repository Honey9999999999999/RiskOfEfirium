using Architecture;
using Assets.Scripts.InputManager;
using UnityEngine;

namespace Assets.Scripts.CraftSystem
{
    [RequireComponent(typeof(Collider))]
    public class WorkBench : MonoBehaviour
    {
        [SerializeField] private WorkBenchType _type;

        private bool _isOpened;
        private PlayerInteractor _playerInteractor;

        private void Start()
        {
            Game.OnGameInitialized += Initialize;
        }
        private void Initialize()
        {
            _playerInteractor = Game.GetInteractor<PlayerInteractor>();
        }

        public void OnTriggerEnter(Collider other)
        {
            if (!other.isTrigger && other.TryGetComponent(out Player _))
            {
                InputHandler.OnInteractionButtonInput += SetActiveCraftWindow;
            }
        }
        public void OnTriggerExit(Collider other)
        {
            if (!other.isTrigger && other.TryGetComponent(out Player _))
            {
                InputHandler.OnInteractionButtonInput -= SetActiveCraftWindow;

                Game.GetInteractor<CraftSystemInteractor>().CraftWindow.CloseWindow();
                _isOpened = false;
            }
        }

        private void SetActiveCraftWindow()
        {
            CraftWindow window = Game.GetInteractor<CraftSystemInteractor>().CraftWindow;

            if (_isOpened)
            {
                window.CloseWindow();
                _isOpened = false;
                _playerInteractor.MenuMode = _isOpened;
            }
            else
            {
                window.OpenWindow(_type);
                _isOpened = true;
                _playerInteractor.MenuMode = _isOpened;
            }
        }
    }
}
