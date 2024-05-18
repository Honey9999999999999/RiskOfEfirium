using Architecture;
using Assets.Scripts.Controllers.EntityControllers;
using EntityControllers;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static event Action<Vector3> OnCameraRotated;

    [SerializeField, Min(0)] private float _sensivity = 0.2f;

    [SerializeField] private EntityController controller;

    public static CameraController instance;

    private Vector3 _cameraPositionOld;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            PlayerInteractor.OnInitialized += () => Game.GetInteractor<PlayerInteractor>().player.GetPlayerController().OnCameraInput += Rotate;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Rotate()
    {
        Vector3 rotation;

        if (Input.GetMouseButtonDown(1))
        {
            _cameraPositionOld = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 mousePositionDelta = _cameraPositionOld - Input.mousePosition;
            _cameraPositionOld = Input.mousePosition;
            rotation = mousePositionDelta;
        }
        else
        {
            _cameraPositionOld = Vector3.zero;
            rotation = Vector3.zero;
        }

        rotation = new(0, -rotation.x * _sensivity, 0);
        transform.Rotate(rotation);

        OnCameraRotated?.Invoke(rotation);
    }
}
