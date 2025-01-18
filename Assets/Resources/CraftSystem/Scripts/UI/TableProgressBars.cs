using Architecture;
using Assets.Scripts.CharacterStatsSystem;
using Assets.Scripts.InventorySystem;
using UnityEngine;

namespace Assets.Scripts.CraftSystem.UI
{
    public class TableProgressBars : MonoBehaviour
    {
        public CharacteristicProgressBar progressBar;

        public bool overrideBarColors;
        public Color32 fillerColor = Color.white;
        public Color backgroundColor = Color.white;
        public Color improveColor = Color.white;
        public Color downgraidColor = Color.white;

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

            Item item = Game.GetInteractor<PlayerInteractor>().Player.Inventory.GetItem(WorkBenchWindow.currentBlueprint.Info.ServiceName);

            foreach (var key in item.ImprovedCharacteristicsMap.Keys)
            {
                CharacteristicProgressBar bar = Instantiate(progressBar, transform);

                if (overrideBarColors)
                {
                    bar.ChangeColors(fillerColor, backgroundColor, improveColor, downgraidColor);
                }

                bar.SetName(CharacteristicLocalizator.GetLocalWord(key));

                float currentIndex = Game.GetInteractor<PlayerInteractor>().Player.PersonalCCC.GetIndexOf(key);
                bar.SetState(currentIndex, currentIndex + item.ImprovedCharacteristicsMap[key]);
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
