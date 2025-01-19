using System;
using System.Collections;
using Assets.Scripts.InputManager;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Scroll
{
    [RequireComponent(typeof(RectTransform), typeof(Mask))]
    public class ScrollRect : MonoBehaviour
    {
        private static ScrollRect ActiveScrollRect { get; set; }

        [SerializeField] private RectTransform _content;
        [SerializeField] private bool _isHorizontal;
        [SerializeField] private bool _isVertical;

        [Space]
        [SerializeField, Range(0, 100)] private float _scrollSensivity;

        [Space]
        [SerializeField] private ScrollBar _verticalScrollBar;
        [SerializeField] private ScrollBar _horizontalScrollBar;

        private Vector2 _stockPosition;

        private float _horizontalDistance;
        private float _verticalDistance;

        private float _offsetX;
        private float _offsetY;

        public void Awake()
        {
            _stockPosition = _content.transform.position;

            if (_verticalScrollBar != null)
            {
                _verticalScrollBar.OnProgressChanged += ScrollByProgress;
                _verticalScrollBar.OnEnabled += ForciblySwitch;
            }
            if (_horizontalScrollBar != null)
            {
                _horizontalScrollBar.OnProgressChanged += ScrollByProgress;
                _horizontalScrollBar.OnEnabled += ForciblySwitch;
            }
        }
        public void OnEnable()
        {
            InputHandler.OnAttackInput += Switch;

            ResetPosition();

            StartCoroutine(Calculate());
            IEnumerator Calculate()
            {
                yield return null;
                CalculateScrollDistance();
            }
        }

        public void OnDisable()
        {
            InputHandler.OnAttackInput -= Switch;

            if (ActiveScrollRect == this)
            {
                InputHandler.OnScrollInput -= Scroll;
                ActiveScrollRect = null;
            }
        }

        private void Switch()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
            {
                ForciblySwitch();
            }
        }

        private void ForciblySwitch()
        {
            if (ActiveScrollRect != this)
            {
                if (ActiveScrollRect != null)
                {
                    InputHandler.OnScrollInput -= ActiveScrollRect.Scroll;
                }

                InputHandler.OnScrollInput += Scroll;
                ActiveScrollRect = this;
            }
        }

        private void ScrollByProgress(float progress)
        {
            if (_isHorizontal && ScrollBar.ActiveScrollBar == _horizontalScrollBar)
            {
                _offsetX = Mathf.Lerp(0, _horizontalDistance, progress);
            }
            else
            {
                _offsetY = Mathf.Lerp(0, _verticalDistance, progress);
            }

            MoveContent();
        }

        private void Scroll(float value)
        {
            if (_isHorizontal && ScrollBar.ActiveScrollBar == _horizontalScrollBar)
            {
                _offsetX = Mathf.Clamp(_offsetX + -value * _scrollSensivity, 0, _horizontalDistance);
            }
            else
            {
                _offsetY = Mathf.Clamp(_offsetY + -value * _scrollSensivity, 0, _verticalDistance);
            }

            if (_horizontalScrollBar != null)
            {
                _verticalScrollBar.Progress = _offsetX == 0 ? 0 : _offsetX / _horizontalDistance;
            }
            if (_verticalScrollBar != null)
            {
                _verticalScrollBar.Progress = _offsetY == 0 ? 0 : _offsetY / _verticalDistance;
            }

            MoveContent();
        }

        private void MoveContent()
        {
            _content.transform.position = new Vector2(
                    _stockPosition.x + _offsetX,
                    _stockPosition.y + _offsetY
                    );
        }

        private void ResetPosition()
        {
            _offsetX = 0;
            _offsetY = 0;

            Scroll(0);
        }

        public void CalculateScrollDistance()
        {
            RectTransform rect = GetComponent<RectTransform>();
            Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(transform, transform);

            if (_isHorizontal)
            {
                float distance = rect.rect.width;
                float finalDistance = bounds.min.x * -1 + bounds.max.x;
                _horizontalDistance = Mathf.Max(0, finalDistance - distance);

                if (_horizontalScrollBar != null)
                {
                    _horizontalScrollBar.ScrollRatio = distance / finalDistance;
                }
            }
            if (_isVertical)
            {
                float distance = rect.rect.height;
                float finalDistance = bounds.min.y * -1 + bounds.max.y;
                _verticalDistance = Mathf.Max(0, finalDistance - distance);

                if (_verticalScrollBar != null)
                {
                    _verticalScrollBar.ScrollRatio = distance / finalDistance;
                }
            }
        }
    }
}
