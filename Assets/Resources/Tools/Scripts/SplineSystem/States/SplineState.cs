using Assets.Scripts.Tools;
using FSM;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SplineSystem
{
    public abstract class SplineState : IState
    {
        protected List<Vector3> _points;
        protected ShellValue<Vector3> _currentPosition;

        protected SplineConfig _config;
        protected ShellValue<float> _lengthPath;
        protected bool _isRunning;

        protected List<VirtualPoint> _prepareVirtualPoints;
        protected List<VirtualPoint> _runningVirtualPoints = new();

        protected SplineTypes _currentType;
        protected Dictionary<SplineTypes, Action> _methodsMap;

        protected SplineState(
            List<Vector3> points,
            List<VirtualPoint> prepareVirtualPoints,
            SplineConfig config,
            ShellValue<float> lengthPath,
            ShellValue<Vector3> currentPosition,
            Dictionary<SplineTypes, Action> methodsMap
            )
        {
            _points = points;
            _config = config;
            _lengthPath = lengthPath;
            _prepareVirtualPoints = prepareVirtualPoints;
            _currentPosition = currentPosition;
            _methodsMap = methodsMap;
        }

        public virtual void Enter()
        {
            if (_config.awakeble)
            {
                _isRunning = true;
            }
        }

        public virtual void Exit()
        {
            ResetVirtualPoints();

            _isRunning = false;
        }

        public virtual void Update()
        {
            if (_currentType != _config.splineType)
            {
                _methodsMap[_config.splineType]?.Invoke();
            }

            if (_isRunning)
            {
                foreach (var vPoint in _runningVirtualPoints.ToArray())
                {
                    vPoint.Update();
                }
            }

            DoStep();
        }

        public virtual void GenerateTruePath() { }

        protected void DoStep()
        {
            _currentPosition.value = Vector3.zero;

            foreach (var vPoint in _prepareVirtualPoints)
            {
                _currentPosition.value += vPoint.currentPosition;
            }

            _currentPosition.value /= _prepareVirtualPoints.Count;
        }

        public void Run()
        {
            _isRunning = true;
        }

        protected int GetDirectionMove()
        {
            return _config.reversed ? -1 : 1;
        }

        protected void CreateVirtualPoints(int count, List<Vector3> path)
        {
            for (int i = 0; i < count; i++)
            {
                _prepareVirtualPoints.Add(new(path, _config));

                _prepareVirtualPoints[i].StandToPosition(0);
                _prepareVirtualPoints[i].SetTargetPosition(_prepareVirtualPoints[i].currentPositionIndex + GetDirectionMove());

                _prepareVirtualPoints[i].OnPathFinished += SetNextTarget;
            }
        }

        protected void ResetVirtualPoints()
        {
            foreach (var vPoint in _prepareVirtualPoints)
            {
                vPoint.OnPathFinished -= SetNextTarget;
            }

            _prepareVirtualPoints.RemoveRange(0, _prepareVirtualPoints.Count);
            _runningVirtualPoints = new();
        }

        private void SetNextTarget(VirtualPoint vPoint)
        {
            if (_config.cyclical ^ (!_config.cyclical && ((!_config.reversed && vPoint.currentPositionIndex < vPoint.path.Count - 1) || (_config.reversed && vPoint.currentPositionIndex > 0))))
            {
                vPoint.SetTargetPosition(vPoint.currentPositionIndex + GetDirectionMove());
            }
        }
    }
}
