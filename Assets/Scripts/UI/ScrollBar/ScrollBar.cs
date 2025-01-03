using System;
using UnityEngine;

namespace Assets.Scripts.UI.Scroll
{
    [RequireComponent(typeof(RectTransform))]
    public class ScrollBar : MonoBehaviour
    {
        public static ScrollBar ActiveScrollBar { get; private set; }

        public event Action OnEnabled;
        public event Action<float> OnProgressChanged;

        public Direction DirectionScroll { get => _direction; set => _direction = value; }
        [SerializeField] private Direction _direction;

        public float Progress
        {
            get => _progress; set
            {
                _progress = Math.Clamp(value, 0, 1);
                MovePosition();
            }
        }
        [SerializeField, Range(0, 1f)] private float _progress = 0;

        public float ScrollRatio
        {
            get => _scrollRatio; set
            {
                _scrollRatio = Math.Clamp(value, 0, 1);
                CalculateSize();
            }
        }
        private float _scrollRatio = .5f;

        [SerializeField] private RectTransform _scrollLine;
        [SerializeField] private Offset _offset;

        private float _maxScrollDistance => (int)_direction < 2
                ? _scrollLine.rect.width - _offset.left - _offset.right
                : _scrollLine.rect.height - _offset.top - _offset.bottom;

        private float _currentScrollSize;
        private float _minSize;

        private Vector2 _axisScroll;
        private Vector2 _startScrollPos;
        private Vector2 _endScrollPos;

        private bool _isActive;
        private Vector2 _oldMousePos;

        public void Awake()
        {
            RectTransform rect = GetComponent<RectTransform>();
            _axisScroll = (int)_direction < 2 ? new(1, 0) : new(0, 1);
            _minSize = Mathf.Min(rect.rect.height, rect.rect.width);
            CalculateSize();
        }

        public void Update()
        {
            if (_isActive)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    _isActive = false;
                    return;
                }

                Vector2 currentMousePos = Input.mousePosition;
                Vector2 difference = currentMousePos - _oldMousePos;
                _oldMousePos = currentMousePos;

                Scroll(difference);

                return;
            }

            if (Input.GetMouseButtonDown(0) && RectTransformUtility.RectangleContainsScreenPoint(GetComponent<RectTransform>(), Input.mousePosition))
            {
                ActiveScrollBar = this;
                _isActive = true;
                _oldMousePos = Input.mousePosition;
                OnEnabled?.Invoke();
            }
        }

        private void Scroll(Vector3 value)
        {
            value *= _axisScroll;

            Vector2 pos = Vector2.ClampMagnitude(transform.localPosition + value, _startScrollPos.magnitude);
            float a = (pos - _startScrollPos).magnitude;
            float b = (_startScrollPos - _endScrollPos).magnitude;

            Progress = a / b;

            OnProgressChanged?.Invoke(Progress);
        }

        private void MovePosition()
        {
            transform.localPosition = Vector2.Lerp(_startScrollPos, _endScrollPos, _progress);
        }

        public void CalculateSize()
        {
            RectTransform scrollRect = GetComponent<RectTransform>();

            scrollRect.sizeDelta = Vector2.Lerp(
                new(_minSize, _minSize),
                new(_axisScroll.x > 0 ? _maxScrollDistance : _minSize,
                    _axisScroll.y > 0 ? _maxScrollDistance : _minSize),
                _scrollRatio);
            _currentScrollSize = _axisScroll.x > 0 ? scrollRect.sizeDelta.x : scrollRect.sizeDelta.y;

            CalculatePath();
            MovePosition();
        }

        private void CalculatePath()
        {
            float distance = _maxScrollDistance - _currentScrollSize;

            _startScrollPos = _direction switch
            {
                Direction.LeftToRight => new Vector2(-distance / 2, 0),
                Direction.RightToLeft => new Vector2(distance / 2, 0),
                Direction.TopToBottom => new Vector2(0, distance / 2),
                Direction.BottomToTop => new Vector2(0, -distance / 2),
                _ => new Vector2(),
            };
            _endScrollPos = _direction switch
            {
                Direction.LeftToRight => new Vector2(distance / 2, 0),
                Direction.RightToLeft => new Vector2(-distance / 2, 0),
                Direction.TopToBottom => new Vector2(0, -distance / 2),
                Direction.BottomToTop => new Vector2(0, distance / 2),
                _ => new Vector2(),
            };
        }

        [Serializable]
        public class Offset
        {
            public int top;
            public int bottom;
            public int left;
            public int right;
        }
    }

    [Serializable]
    public enum Direction
    {
        LeftToRight,
        RightToLeft,
        TopToBottom,
        BottomToTop
    }
}
