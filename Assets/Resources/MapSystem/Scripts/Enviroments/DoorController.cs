using UnityEngine;

namespace Assets.Scripts.Enviroments
{
    [RequireComponent(typeof(Animator))]
    public class DoorController : MonoBehaviour
    {
        Animator animator;

        public void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                bool isOpen = animator.GetBool("isOpen");
                animator.SetBool("isOpen", !isOpen);
            }
        }
    }
}
