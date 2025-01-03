using UnityEngine;

namespace Assets.Scripts.CraftSystem.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class FillerOfProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform mask;

        private RectTransform rect;

        private float distance;
        private float startWidth;

        private const int cornerOffset = 21;

        public void Awake()
        {
            distance = mask.rect.width - cornerOffset;
            rect = GetComponent<RectTransform>();
            startWidth = rect.rect.width;
        }

        public void SetState(float index)
        {
            Vector2 size = rect.sizeDelta;
            size.x = Mathf.Lerp(startWidth, startWidth + distance, index);
            rect.sizeDelta = size;
            Debug.Log(index);
        }
    }
}
