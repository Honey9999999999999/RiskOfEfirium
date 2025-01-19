using System;
using System.Collections.Generic;
using Assets.Scripts.Tools;
using UnityEngine;

namespace SplineSystem
{
    public class SplineVSmoothState : SplineState
    {
        private float _timer;
        private List<Vector3> _pathLine;
        private bool isPathDone;



        public SplineVSmoothState(List<Vector3> points, List<VirtualPoint> prepareVirtualPoints, List<Vector3> pathLine, SplineConfig config, ShellValue<float> lengthPath, ShellValue<Vector3> currentPosition, Dictionary<SplineTypes, Action> methodsMap) : base(points, prepareVirtualPoints, config, lengthPath, currentPosition, methodsMap)
        {
            _currentType = SplineTypes.SmoothByVirtualPoints;
            _pathLine = pathLine;
        }

        private float _timeToStart
        {
            get
            {
                return _config.smoothForce / (_config.smoothAccuracy * _lengthPath.value * _config.speed);
            }
        }

        public override void Enter()
        {
            base.Enter();

            GenerateTruePath();
            CreateVirtualPoints(1, _pathLine);
        }

        private void RebuildTruePath()
        {
            isPathDone = false;
            _pathLine.RemoveRange(0, _pathLine.Count);

            ResetVirtualPoints();
            GenerateTruePath();
            CreateVirtualPoints(1, _pathLine);
        }

        public override void GenerateTruePath()
        {
            CreateVirtualPoints(_config.smoothAccuracy, _points);
            _timer = 0;

            while (_runningVirtualPoints.Count < _prepareVirtualPoints.Count)
            {
                _timer += 0.02f;

                if (_timer >= _timeToStart)
                {
                    _runningVirtualPoints.Add(_prepareVirtualPoints[_runningVirtualPoints.Count]);

                    _timer = 0;
                }

                UpdateVPoints();

                if (!_config.cyclical)
                {
                    GeneratePath();
                }
            }

            _runningVirtualPoints[^1].OnAllPathFinished += (VirtualPoint vPoint) => isPathDone = true;

            while (!isPathDone)
            {
                UpdateVPoints();
                GeneratePath();
            }

            _runningVirtualPoints[^1].OnAllPathFinished -= (VirtualPoint vPoint) => isPathDone = true;

            ResetVirtualPoints();
        }
        private void UpdateVPoints()
        {
            foreach (var vPoint in _runningVirtualPoints)
            {
                vPoint.Update(true);
            }
        }
        private void GeneratePath()
        {
            DoStep();
            _pathLine.Add(_currentPosition.value);
        }

        public override void Exit()
        {
            base.Exit();

            isPathDone = false;
            _pathLine.RemoveRange(0, _pathLine.Count);
        }

        public override void Update()
        {
            base.Update();

            if (_config.isConfigChanged)
            {
                RebuildTruePath();
            }

            if (_isRunning)
            {
                if (_runningVirtualPoints.Count < _prepareVirtualPoints.Count)
                {
                    _timer += Time.fixedDeltaTime;

                    if (_timer >= _timeToStart)
                    {
                        _runningVirtualPoints.Add(_prepareVirtualPoints[_runningVirtualPoints.Count]);

                        _timer = 0;
                    }
                }
            }
        }
    }
}
