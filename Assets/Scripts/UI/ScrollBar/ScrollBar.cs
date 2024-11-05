using Assets.Scripts.InputManager;
using System;
using UnityEngine;

namespace Assets.Scripts.UI.Scroll
{
    [RequireComponent(typeof(RectTransform))]
    public class ScrollBar : MonoBehaviour
    {
        public event Action<float> OnScroll;

        public Direction DirectionScroll { get => _direction; set => _direction = value; }
        [SerializeField] private Direction _direction;
        public float Sensivity { get => _sensivity; set => _sensivity = Math.Clamp(value, 0, 1); }
        [SerializeField, Range(0, 1f)] private float _sensivity;
        public float Progress { get => _progress; set => _progress = Math.Clamp(value, 0, 1); }
        [SerializeField, Range(0, 1f)] private float _progress;

        public float ScrollRatio { get => _scrollRatio; set 
            {
                _scrollRatio = Math.Clamp(value, 0, 1);
                CalculateScrollSize();
            }
        }
        private float _scrollRatio = 1;

        [SerializeField] private RectTransform _scrollLine;
        [SerializeField] private Offset _offset;

        private float _maxScrollDistance => (int)_direction < 2
                ? _scrollLine.rect.width - _offset.left - _offset.right
                : _scrollLine.rect.height - _offset.top - _offset.bottom;

        private float _currentScrollSize;

        private Vector2 _startScrollPos;
        private Vector2 _endScrollPos;


        public void OnEnable()
        {
            Progress = 0;
            Scroll(0);
        }

        public void TurnOn()
        {
            InputHandler.OnScrollInput += Scroll;
        }
        public void TurnOff()
        {
            InputHandler.OnScrollInput -= Scroll;
        }

        private void Scroll(float value)
        {
            Progress += -value * _sensivity * _scrollRatio;
            transform.localPosition = Vector2.Lerp(_startScrollPos, _endScrollPos, Progress);
            OnScroll?.Invoke(Progress);
        }

        public void CalculateScrollSize()
        {
            RectTransform scrollRect = GetComponent<RectTransform>();

            if ((int)_direction < 2)
            {                
                scrollRect.sizeDelta = Vector2.Lerp(new(scrollRect.rect.height, scrollRect.rect.height), new(_maxScrollDistance, scrollRect.rect.height), _scrollRatio);
                _currentScrollSize = scrollRect.sizeDelta.x;
            }
            else
            {
                scrollRect.sizeDelta = Vector2.Lerp(new(scrollRect.rect.width, scrollRect.rect.width), new(scrollRect.rect.width, _maxScrollDistance), _scrollRatio);
                _currentScrollSize = scrollRect.sizeDelta.y;
            }

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

            Scroll(0);
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
