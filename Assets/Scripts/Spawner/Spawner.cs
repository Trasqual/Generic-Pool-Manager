using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] ObjectPoolManager objectPoolManager;
    List<SuperDuperCubeObject> cubes = new();
    List<CrazyAmazingSphereObject> spheres = new();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var spawn = objectPoolManager.GetObject<SuperDuperCubeObject>();
            cubes.Add(spawn);
        }

        if (Input.GetMouseButtonDown(1))
        {
            var spawn = objectPoolManager.GetObject<CrazyAmazingSphereObject>();
            spheres.Add(spawn);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (var cube in cubes)
            {
                objectPoolManager.ReleaseObject(cube);
            }
            cubes.Clear();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var sphere in spheres)
            {
                objectPoolManager.ReleaseObject(sphere);
            }
            spheres.Clear();
        }
    }
}
