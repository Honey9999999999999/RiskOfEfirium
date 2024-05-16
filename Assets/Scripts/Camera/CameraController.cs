using Architecture;
using Assets.Scripts.Controllers.EntityControllers;
using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static event Action<Vector3> OnCameraRotated;

    [SerializeField, Min(0)] private float _sensivity = 0.2f;

    [SerializeField] private EntityController controller;

    public static CameraController instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            PlayerInteractor.OnInitialized += () => Game.GetInteractor<PlayerInteractor>().player.GetEntityController().OnCameraInput += Rotate;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Rotate()
    {
        Vector3 rotation = new(0, -controller.CameraControlInput.x * _sensivity, 0);
        transform.Rotate(rotation);

        OnCameraRotated?.Invoke(rotation);
    }
}
