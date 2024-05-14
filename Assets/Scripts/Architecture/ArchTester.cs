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
        MiniMapInteractor mapInteractor;
        LabyrinthInteractor labyrinthInteractor;
        PlayerPositionInteractor player;

        private void Start()
        {
            Game.Run();

            bank = Game.GetInteractor<BankInteractor>();
            mapInteractor = Game.GetInteractor<MiniMapInteractor>();
            labyrinthInteractor = Game.GetInteractor<LabyrinthInteractor>();
            player = Game.GetInteractor<PlayerPositionInteractor>();
        }

        private void Update()
        {
            if (!Game.sceneManager.isLoading)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    labyrinthInteractor.OnCreate();
                    mapInteractor.ReDrawMap();
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    player.GoOn(Direction.Top);
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    player.GoOn(Direction.Left);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    player.GoOn(Direction.Down);
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    player.GoOn(Direction.Right);
                }
            }
        }
    }
}
