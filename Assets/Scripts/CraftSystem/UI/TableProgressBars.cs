using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;
using UnityEngine;

namespace Assets.Scripts.CraftSystem.UI
{
    public class TableProgressBars : MonoBehaviour
    {
        [SerializeField] private CharacteristicProgressBar _progressBar;

        public void OnEnable()
        {
            ItemCreator.OnCrafted += SetBlueprint;
        }
        public void OnDisable()
        {
            ItemCreator.OnCrafted -= SetBlueprint;
        }

        public void SetBlueprint()
        {
            Clear();

            Item item = Game.GetInteractor<InventorySystemInteractor>().PlayerInventory.GetItem(WorkBenchWindow.currentBlueprint.ItemName);

            foreach (var key in item.ImprovedCharacteristicsMap.Keys)
            {
                CharacteristicProgressBar progressBar = Instantiate(_progressBar, transform);
                progressBar.SetName(CharacteristicLocalizator.GetLocalWord(key));

                float currentIndex = Game.GetInteractor<PlayerInteractor>().player.PersonalCCC.GetIndexOf(key);
                progressBar.SetState(currentIndex, currentIndex + item.ImprovedCharacteristicsMap[key]);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
