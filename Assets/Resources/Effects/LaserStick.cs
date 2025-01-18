using Assets.Scripts.Controllers.EntityControllers;
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

        BattleState.OnBattleModeEnter += TurnLaser;        
        BattleState.OnBattleModeExit += TurnLaser;        

        _lineRenderer.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        InputHandler.OnMoveInput += ReplaceLaser;
        FlyingState.OnPlayerRotated += ReplaceLaser;
    }
    private void OnDisable()
    {
        InputHandler.OnMoveInput -= ReplaceLaser;
        FlyingState.OnPlayerRotated -= ReplaceLaser;
    }

    private void ReplaceLaser()
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
    private void ReplaceEndPoint()
    {
        if (_endPoint != null)
        {
            _endPoint.transform.position = _lineRenderer.GetPosition(1);
        }
    }

    private void TurnLaser()
    {
        _lineRenderer.gameObject.SetActive(!_lineRenderer.gameObject.activeSelf);
    }
}
