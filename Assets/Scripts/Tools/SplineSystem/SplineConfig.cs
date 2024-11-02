using System;
using UnityEngine;

namespace SplineSystem
{
    [Serializable]
    public class SplineConfig
    {
        public event Action OnConfigChanged;

        public SplineTypes splineType;

        [Space]
        [Min(0)] public float speed;

        [Space]
        public bool awakeble;
        public bool cyclical;
        public bool reversed;

        [Space, Header("Smooth Spline Config")]
        [Range(1, 10)] public int smoothAccuracy;
        [Range(0, 10)] public float smoothForce;

        private bool _isOldCyclical;
        private int _isOldSmoothAccuracy;
        private float _isOldSmoothForce;

        public bool isConfigChanged
        {
            get
            {
                if ((_isOldCyclical != cyclical) ||
                (_isOldSmoothAccuracy != smoothAccuracy) ||
                (_isOldSmoothForce != smoothForce))
                {
                    _isOldCyclical = cyclical;
                    _isOldSmoothAccuracy = smoothAccuracy;
                    _isOldSmoothForce = smoothForce;

                    OnConfigChanged?.Invoke();

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
