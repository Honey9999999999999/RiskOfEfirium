using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Image), typeof(RectTransform))]
    public class CustomImageFiller : MonoBehaviour
    {
        [SerializeField] private RectTransform mask;

        private RectTransform filler;
        private float startWidth;
        private float distance;

        public float FillAmount
        {
            get { return fillAmount; }
            set
            {
                fillAmount = Mathf.Clamp(value, 0, 1);
                ChangeFillLevel();
            }
        }

        private float fillAmount;

        private void Awake()
        {
            filler = GetComponent<RectTransform>();
            startWidth = filler.sizeDelta.x;
            distance = startWidth + mask.sizeDelta.x;
        }

        private void ChangeFillLevel()
        {
            Vector2 size = new(Mathf.Lerp(startWidth, distance, fillAmount), filler.sizeDelta.y);
            filler.sizeDelta = size;
        }
    }
}
