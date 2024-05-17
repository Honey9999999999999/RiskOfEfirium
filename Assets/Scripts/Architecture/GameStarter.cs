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
    }
}
