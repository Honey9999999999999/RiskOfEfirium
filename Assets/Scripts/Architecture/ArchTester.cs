using Architecture;
using Assets.Scripts.Bank;
using Assets.Scripts.LabyrinthGenerator;
using Assets.Scripts.MapDrawer;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        BankInteractor bank;
        MiniMapInteractor mapInteractor;
        LabyrinthInteractor labyrinthInteractor;

        private void Start()
        {
            Game.Run();

            bank = Game.GetInteractor<BankInteractor>();
            mapInteractor = Game.GetInteractor<MiniMapInteractor>();
            labyrinthInteractor = Game.GetInteractor<LabyrinthInteractor>();
        }

        private void Update()
        {
            if (!Game.sceneManager.isLoading)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    labyrinthInteractor.levelMap.Rotate();
                    mapInteractor.ReDrawMap();
                }
                if (Input.GetKeyDown(KeyCode.O))
                {
                    labyrinthInteractor.levelMap.rooms[0].OverrideCenter(labyrinthInteractor.levelMap.rooms[0].blocks[0]);
                }

                if (Input.GetKeyDown(KeyCode.A))
                {
                    bank.AddCoins(5);

                    Debug.Log($"Bank have {bank.GetCoins()} coins");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    bank.SpendCoins(10);

                    Debug.Log($"Bank have {bank.GetCoins()} coins");
                }
            }            
        }
    }
}
