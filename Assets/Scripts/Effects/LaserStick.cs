using Assets.Scripts.InputManager;
using PlayerMoveStates;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserStick : MonoBehaviour
{
    [SerializeField] LayerMask layers;
    [SerializeField] ParticleSystem _endPoint;

    private LineRenderer _lineRenderer;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        InputHandler.OnTabInput += TurnLaser;
        InputHandler.OnMoveInput += ReplaceLaser;
        FlyingState.OnPlayerRotated += ReplaceLaser;

        _lineRenderer.enabled = false;

        if (_endPoint != null)
        {
            _endPoint.Stop();
        }
    }

    private void ReplaceLaser()
    {
        if (_lineRenderer.enabled)
        {
            _lineRenderer.SetPosition(0, transform.parent.position);

            Vector3 dir = transform.parent.forward;
            if (Physics.Raycast(transform.parent.position, dir, out RaycastHit hit, 99, layers, QueryTriggerInteraction.Ignore))
            {
                _lineRenderer.SetPosition(1, hit.point);
            }
            else
            {
                _lineRenderer.SetPosition(1, transform.parent.position + transform.parent.forward * 99);
            }

            ReplaceEndPoint();
        }
    }
    private void ReplaceEndPoint()
    {
        if (_endPoint != null)
        {
            _endPoint.transform.position = _lineRenderer.GetPosition(1);
        }
    }

    private void TurnLaser()
    {
        _lineRenderer.enabled = !_lineRenderer.enabled;

        if (_endPoint != null)
        {
            if (_lineRenderer.enabled)
            {
                _endPoint.Play();
            }
            else
            {
                _endPoint.Stop();
            }
        }
    }
}
