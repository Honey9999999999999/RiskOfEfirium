using Architecture;
using Assets.Scripts.Bank;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.MapDrawer;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        BankInteractor bank;
        //MiniMapInteractor mapInteractor;
        //LabyrinthInteractor labyrinthInteractor;
        PlayerTransition player;

        private void Start()
        {
            Game.Run();
        }

        private void Update()
        {
            if (!Game.sceneManager.isLoading)
            {

            }
        }
    }
}
