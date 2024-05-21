using Architecture;
using Assets.Scripts.Tools;
using UI.Cursor;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class GameStarter : MonoBehaviour
    {
        private void Start()
        {
            Game.Run();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && CursorHitHandler.RaycastNoTriggers(out RaycastHit hit))
            {
                Debug.Log(hit.point);

                if(hit.collider.TryGetComponent<Enemy>(out _))
                {
                    Debug.Log("I see Enemy");
                }
            }
        }
    }
}
