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

        [SerializeField] private Image background;

        private Color32 _improveColor = Color.green;
        private Color32 _downgraidColor = Color.red;

        private Image imageOfFillerProgress;

        public void Awake()
        {
            imageOfFillerProgress = fillerOfProgress.GetComponent<Image>();
        }

        public void ChangeColors(Color32 filler, Color32 background, Color32 improve, Color32 downgraid)
        {
            this.filler.GetComponent<Image>().color = filler;
            this.background.color = background;

            _improveColor = improve;
            _downgraidColor = downgraid;
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
                imageOfFillerProgress.color = _improveColor;
            }
            else
            {
                DistributeIndexes(fillerOfProgress, filler);
                imageOfFillerProgress.color = _downgraidColor;
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
