using Architecture;
using UnityEngine;

namespace Assets.Scripts.Bank
{
    public class BankRepositories : Repositories
    {
        public static string KEY = "BANK_KEY";

        private int _coins;
        public int coins
        {
            get
            {
                return _coins;
            }
            set
            {
                if (value >= 0)
                {
                    _coins = value;
                }
                else
                {
                    throw new System.Exception("Coins in Bank can't be lower zero");
                }
            }
        }

        public override void OnCreate()
        {

        }
        public override void Initialize()
        {
            coins = PlayerPrefs.GetInt(KEY);
        }
        public override void OnStart()
        {

        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, coins);
        }
    }
}
