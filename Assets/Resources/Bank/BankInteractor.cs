using Architecture;
using UnityEngine;

namespace Assets.Scripts.Bank
{
    public class BankInteractor : Interactor
    {
        private BankRepositories bank;

        public override void OnCreate()
        {
            base.OnCreate();

            bank = Game.GetRepository<BankRepositories>();
        }

        public override void Initialize()
        {
            base.Initialize();

            Debug.Log($"Bank Initialized! {bank.coins} coins");
        }

        public void AddCoins(int value)
        {
            bank.coins += value;
            bank.Save();
        }
        public void SpendCoins(int value)
        {
            if (IsEnougthCoins(value))
            {
                bank.coins -= value;
                bank.Save();
            }
            else
            {
                Debug.Log(new string($"Bank has't {value} coins"));
            }
        }
        public bool IsEnougthCoins(int value)
        {
            return bank.coins >= value;
        }

        public int GetCoins() => bank.coins;
    }
}
