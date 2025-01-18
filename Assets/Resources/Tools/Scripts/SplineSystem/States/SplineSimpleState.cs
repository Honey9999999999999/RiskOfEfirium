using Assets.Scripts.Tools;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SplineSystem
{
    public class SplineSimpleState : SplineState
    {
        public SplineSimpleState(List<Vector3> points, List<VirtualPoint> prepareVirtualPoints, SplineConfig config, ShellValue<float> lengthPath, ShellValue<Vector3> currentPosition, Dictionary<SplineTypes, Action> methodsMap) : base(points, prepareVirtualPoints, config, lengthPath, currentPosition, methodsMap)
        {
            _currentType = SplineTypes.Simple;
        }

        public override void Enter()
        {
            base.Enter();

            CreateVirtualPoints(1, _points);
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            base.Update();

            if (_isRunning)
            {
                if (_runningVirtualPoints.Count < _prepareVirtualPoints.Count)
                {
                    _runningVirtualPoints.Add(_prepareVirtualPoints[_runningVirtualPoints.Count]);
                }
            }
        }
    }
}
