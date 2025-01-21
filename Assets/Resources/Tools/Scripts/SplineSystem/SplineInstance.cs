using System;
using System.Collections.Generic;
using Assets.Scripts.Tools;
using FSM;
using UnityEngine;

namespace SplineSystem
{
    public class SplineInstance : FSMExample<SplineFSM, SplineState>
    {
        [SerializeField]
        private List<Vector3> _points = new()
        {
            new()
        };

        [SerializeField] private SplineConfig _splineConfig;

        private List<VirtualPoint> _virtualPoints = new();
        private List<Vector3> _pathLine = new();

        private ShellValue<Vector3> _currentPosition = new();
        private ShellValue<float> _lenghtPath = new();

        private Dictionary<SplineTypes, Action> _methodsMap;

        private void Start()
        {
            CalculateLengthPath();

            _methodsMap = new()
            {
                [SplineTypes.Simple] = () => _stateMachine.EnterIn<SplineSimpleState>(),
                [SplineTypes.SmoothByVirtualPoints] = () => _stateMachine.EnterIn<SplineVSmoothState>()
            };

            _stateMachine.AddState(new SplineSimpleState(_points, _virtualPoints, _splineConfig, _lenghtPath, _currentPosition, _methodsMap));
            _stateMachine.AddState(new SplineVSmoothState(_points, _virtualPoints, _pathLine, _splineConfig, _lenghtPath, _currentPosition, _methodsMap));

            _methodsMap[_splineConfig.splineType]?.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            DrawAllDebug();
        }
        private void OnDrawGizmos()
        {
            DrawMap();
        }

        public void Run()
        {
            _stateMachine.currentState.Run();
        }

        public void TurnAround()
        {
            _splineConfig.reversed = !_splineConfig.reversed;
        }

        private void CalculateLengthPath()
        {
            _lenghtPath.value = 0;

            for (int i = 1; i < _points.Count; i++)
            {
                _lenghtPath.value += Vector3.Distance(_points[i - 1], _points[i]);
            }
        }

        /// <summary>
        /// Debug
        /// </summary>

        private void DrawAllDebug()
        {
            DrawMap();

            if (Application.isPlaying)
            {
                DrawCurrentPositionPoint();
                DrawVirtualPoints();
            }
            Drawer.DrawCurve(_pathLine, transform.position, Color.green);
        }

        private void DrawMap()
        {
            foreach (var point in _points)
            {
                Drawer.DrawDiamondPoint(point + transform.position, 0.1f, Color.white);
            }

            if (_splineConfig.cyclical)
            {
                Drawer.DrawPolyhedralFigure(_points, transform.position, Color.white);
            }
            else
            {
                Drawer.DrawCurve(_points, transform.position, Color.white);
            }
        }

        private void DrawCurrentPositionPoint()
        {
            Drawer.DrawDiamondPoint(_currentPosition.value + transform.position, 0.15f, new Color32(0, 255, 125, 255));
            Drawer.DrawDiamondPoint(_currentPosition.value + transform.position, 0.075f, new Color32(0, 125, 255, 255));
        }
        private void DrawVirtualPoints()
        {
            foreach (var vPoint in _virtualPoints)
            {
                Drawer.DrawDiamondPoint(vPoint.currentPosition + transform.position, 0.1f, new Color32(155, 155, 255, 255));
            }
        }
    }
}
