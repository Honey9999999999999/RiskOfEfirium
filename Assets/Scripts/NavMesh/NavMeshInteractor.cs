using Architecture;
using Assets.Scripts.Tools;
using Unity.AI.Navigation;

public class NavMeshInteractor : Interactor
{
    private const string NAV_MESH_PATH = "Prefabs/NavMesh/NavMesh";
    private NavMeshSurface _navMesh;

    public override void Initialize()
    {
        base.Initialize();

        _navMesh.BuildNavMesh();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        _navMesh = Instantiater.Instantiate<NavMeshSurface>(NAV_MESH_PATH);
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
