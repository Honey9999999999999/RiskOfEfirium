using Assets.Scripts.InputManager;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Scroll
{
    [RequireComponent(typeof(RectTransform), typeof(Mask))]
    public class ScrollRect : MonoBehaviour
    {
        private static ScrollRect ActiveScrollRect { get; set; }

        [SerializeField] private ScrollBar _scroller;
        [SerializeField] private RectTransform _root;

        private Vector2 _stockPosition;
        private float _distanceDifference;

        public void Awake()
        {
            _stockPosition = transform.position;

            if (_scroller != null)
            {
                _scroller.OnScroll += Move;
            }
        }
        public void OnEnable()
        {
            InputHandler.OnAttackInput += Switch;

            StartCoroutine(Calculate());
            
            IEnumerator Calculate()
            {
                yield return null;
                CalculateRatio();
            }
        }        

        public void OnDisable()
        {
            InputHandler.OnAttackInput -= Switch;

            if (ActiveScrollRect == this)
            {
                ActiveScrollRect._scroller.TurnOff();
                ActiveScrollRect = null;
            }
        }

        private void Switch()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition) && ActiveScrollRect != this)
            {
                if (ActiveScrollRect != null)
                {
                    ActiveScrollRect._scroller.TurnOff();
                }

                _scroller.TurnOn();
                ActiveScrollRect = this;
            }
        }

        private void Move(float progress)
        {
            Vector2 endPos = (int)_scroller.DirectionScroll < 2 
                ? new(_stockPosition.x + (_scroller.DirectionScroll == Direction.LeftToRight ? _distanceDifference : -_distanceDifference), _stockPosition.y) 
                : new(_stockPosition.x, _stockPosition.y + (_scroller.DirectionScroll == Direction.TopToBottom ? _distanceDifference : -_distanceDifference));
            _root.position = Vector2.Lerp(_stockPosition, endPos, progress);
        }

        public void CalculateRatio()
        {
            if(_scroller != null)
            {
                RectTransform rect = GetComponent<RectTransform>();
                float distance = (int)_scroller.DirectionScroll < 2 ? rect.rect.width : rect.rect.height;

                Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(transform, transform);
                float finalDistance = (int)_scroller.DirectionScroll < 2 ? bounds.min.x * -1 + bounds.max.x : bounds.min.y * -1 + bounds.max.y;

                _distanceDifference = finalDistance - distance;

                _scroller.ScrollRatio = distance / finalDistance;
            }            
        }
    }
}
