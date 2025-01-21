using UnityEngine;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Collider))]
    public class PopupMessage : MonoBehaviour
    {
        public bool isShowing = true;

        [SerializeField] private GameObject message;
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isShowing && !other.isTrigger && other.TryGetComponent(out Player _))
                message.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (isShowing && !other.isTrigger && other.TryGetComponent(out Player _))
                message.SetActive(false);
        }

        private void OnTriggerStay(Collider other)
        {
            if (isShowing && !other.isTrigger && other.TryGetComponent(out Player _) && mainCamera != null)
            {
                message.transform.LookAt(message.transform.position + mainCamera.transform.forward);
            }
        }

        public void TurnOff()
        {
            isShowing = false;
            message.SetActive(false);
        }
    }
}
