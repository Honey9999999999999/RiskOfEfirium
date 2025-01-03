using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.CraftSystem.UI
{
    public class CharacteristicProgressBar : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI characteristicName;

        [SerializeField] private FillerOfProgressBar filler;
        [SerializeField] private FillerOfProgressBar fillerOfProgress;

        private Image imageOfFillerProgress;

        public void Awake()
        {
            imageOfFillerProgress = fillerOfProgress.GetComponent<Image>();
        }

        public void SetName(string text)
        {
            characteristicName.text = text;
        }

        public void SetState(float oldIndex, float newIndex)
        {
            if (IsPossitiveImprove(oldIndex, newIndex))
            {
                DistributeIndexes(filler, fillerOfProgress);
                imageOfFillerProgress.color = Color.green;
            }
            else
            {
                DistributeIndexes(fillerOfProgress, filler);
                imageOfFillerProgress.color = Color.red;
            }

            void DistributeIndexes(FillerOfProgressBar less, FillerOfProgressBar more)
            {
                less.SetState(oldIndex);
                more.SetState(newIndex);
            }
        }

        private bool IsPossitiveImprove(float oldIndex, float newIndex)
        {
            return newIndex >= oldIndex;
        }
    }
}
