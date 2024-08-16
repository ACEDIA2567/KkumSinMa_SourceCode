using UnityEngine;
using NavMeshPlus.Components;

public class NavMeshBuild : MonoBehaviour
{
    private NavMeshSurface surface;

    void Awake()
    {
        surface = GetComponent<NavMeshSurface>();
    }

    private void OnEnable()
    {
        surface.BuildNavMeshAsync();
    }
}
