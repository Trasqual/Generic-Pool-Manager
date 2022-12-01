using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] List<MonoBehaviour> prefabs = new();

    private List<ObjectPool<MonoBehaviour>> pools = new();

    public MonoBehaviour GetObject<T>() where T : MonoBehaviour
    {
        if (GetPool<T>() == null)
        {
            var newPool = new ObjectPool<T>(() => Spawn<T>(), OnGetFromPool, OnReleaseToPool, OnDestroyAtPool);
            pools.Add(newPool as ObjectPool<MonoBehaviour>);
        }
        return GetPool<T>().Get();
    }

    private T Spawn<T>() where T : MonoBehaviour
    {
        return Instantiate(GetPrefab<T>());
    }

    private void OnGetFromPool(MonoBehaviour spawn)
    {
        spawn.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(MonoBehaviour spawn)
    {
        spawn.gameObject.SetActive(false);
    }

    private void OnDestroyAtPool(MonoBehaviour spawn)
    {
        Destroy(spawn.gameObject);
    }

    private T GetPrefab<T>() where T : MonoBehaviour
    {
        return prefabs.FirstOrDefault((prefab) => prefab.GetType() == typeof(T)) as T;
    }

    private ObjectPool<T> GetPool<T>() where T : MonoBehaviour
    {
        if (pools.Count == 0) return null;
        foreach (var pool in pools)
        {
            Debug.Log(pool);
            Debug.Log(pool.GetType());
            Debug.Log(typeof(T));
            if (pool.GetType().GetGenericArguments()[0] is T)
            {
                return pool as ObjectPool<T>;
            }
        }

        return null;
    }
}
