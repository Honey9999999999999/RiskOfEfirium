using Architecture;
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Game.GetInteractor<PlayerInteractor>().player.TakenDamage(10);
            }
        }
    }
}
