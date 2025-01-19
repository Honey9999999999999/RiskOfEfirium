using System;
using Assets.Scripts.InputManager;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static event Action<Vector3> OnCameraRotated;

    [SerializeField, Min(0)] private float _sensivity = 0.2f;

    public static CameraController instance;

    private Vector3 _cameraPositionOld;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            InputHandler.OnCameraFirstInput += SaveCameraPosition;
            InputHandler.OnCameraInput += Rotate;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void SaveCameraPosition() => _cameraPositionOld = Input.mousePosition;
    private void Rotate()
    {
        Vector3 mousePositionDelta = _cameraPositionOld - Input.mousePosition;
        _cameraPositionOld = Input.mousePosition;

        Vector3 rotation = new(0, -mousePositionDelta.x * _sensivity, 0);
        transform.Rotate(rotation);

        OnCameraRotated?.Invoke(rotation);
    }
}
