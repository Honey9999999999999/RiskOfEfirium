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

        public void OnTriggerEnter(Collider other)
        {
            if(!other.isTrigger && other.TryGetComponent(out Player _))
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
            }            
        }

        private void SetActiveCraftWindow()
        {
            CraftWindow window = Game.GetInteractor<CraftSystemInteractor>().CraftWindow;

            if (_isOpened)
            {
                window.CloseWindow();
                _isOpened = false;
            }
            else
            {
                window.OpenWindow(_type);
                _isOpened = true;
            }            
        }
    }
}
