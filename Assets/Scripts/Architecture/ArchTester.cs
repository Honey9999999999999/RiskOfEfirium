using Architecture;
using Assets.Scripts.Bank;
using UnityEngine;

namespace Assets.Scripts.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        BankInteractor bank;

        private void Start()
        {
            Game.Run();

            bank = Game.GetInteractor<BankInteractor>();
        }

        private void Update()
        {
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
