using System;
using System.Collections.Generic;
using UnityEngine;

namespace SplineSystem
{
    [Serializable]
    public class VirtualPoint
    {
        public event Action<VirtualPoint> OnPathFinished;
        public event Action<VirtualPoint> OnAllPathFinished;

        public const float FIXED_DELTA_TIME = 0.02f;

        private float _timeToRoad;
        private float _timer;

        private float _indexPath;

        private SplineConfig _config;

        public VirtualPoint(List<Vector3> path, SplineConfig config)
        {
            this.path = path;
            _config = config;
        }

        public List<Vector3> path { get; private set; }

        public int currentPositionIndex { get; private set; }
        public int _targetPositionIndex { get; private set; }

        public Vector3 currentPosition { get; private set; }

        public void Update(bool isVirual = false)
        {
            if (_timer >= _timeToRoad)
            {
                StandToPosition(_targetPositionIndex);
                OnPathFinished?.Invoke(this);

                if ((_config.cyclical && currentPositionIndex == 0) || (!_config.cyclical && currentPositionIndex == path.Count - 1))
                {
                    OnAllPathFinished?.Invoke(this);
                }
            }

            _timer += isVirual ? FIXED_DELTA_TIME : Time.fixedDeltaTime;

            _indexPath = _timer / _timeToRoad;

            currentPosition = Vector3.Lerp(path[currentPositionIndex], path[_targetPositionIndex], _indexPath);
        }

        public void StandToPosition(int index)
        {
            currentPositionIndex = index;
            currentPositionIndex = Clamp(currentPositionIndex);

            currentPosition = path[currentPositionIndex];
        }
        public void SetTargetPosition(int index)
        {
            _targetPositionIndex = index;
            _targetPositionIndex = Clamp(_targetPositionIndex);

            PrepareToNextTarget();
        }

        private int Clamp(int value)
        {
            return value > path.Count - 1 ? 0 :
                                    value < 0 ? path.Count - 1 : value;
        }

        private void PrepareToNextTarget()
        {
            ResetTimer();
            CalculateTime();
        }
        private void ResetTimer()
        {
            _timer = 0;
        }
        private void CalculateTime()
        {
            float distance = Vector3.Distance(path[currentPositionIndex], path[_targetPositionIndex]);
            _timeToRoad = distance / _config.speed;
        }
    }
}
