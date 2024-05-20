using Architecture;
using Assets.Scripts.Tools;
using Cinemachine;
using UnityEngine;

public class CameraInteractor : Interactor
{
    private const string MAIN_CAMERA_PATH = "Prefabs/Camera/MainCamera";
    private CinemachineVirtualCamera _camera;
    public CinemachineVirtualCamera camera => _camera;
    public override void Initialize()
    {
        base.Initialize();

        Transform viewPort = Game.GetInteractor<PlayerInteractor>().player.GetViewPort();

        _camera.Follow = viewPort;
        _camera.LookAt = viewPort;

        Camera.SetupCurrent(_camera.GetComponent<Camera>());
    }

    public override void OnCreate()
    {
        base.OnCreate();

        GameObject cameraObj = Instantiater.Instantiate<GameObject>(MAIN_CAMERA_PATH);
        cameraObj.transform.position = new Vector3(0, 1, 0);

        if (!cameraObj.TryGetComponent(out _camera))
        {
            throw new System.Exception("cameraObj has't script \"CinemachineVirtualCamera\"");
        }
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
