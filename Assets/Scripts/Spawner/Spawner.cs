using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] ObjectPoolManager objectPoolManager;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var spawn = objectPoolManager.GetObject<SuperDuperCubeObject>();
        }
    }
}
