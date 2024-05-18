using Architecture;
using Assets.Scripts.Tools;
using Unity.AI.Navigation;

public class NavMeshInteractor : Interactor
{
    private const string NAV_MESH_PATH = "Prefabs/NavMesh/NavMesh";
    public NavMeshSurface _navMesh { get; private set; }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void OnCreate()
    {
        base.OnCreate();

        _navMesh = Instantiater.Instantiate<NavMeshSurface>(NAV_MESH_PATH);
        _navMesh.BuildNavMesh();
    }

    public override void OnStart()
    {
        base.OnStart();
    }
}
