using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectsPool<TPoolingObject> : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private PoolingObject[] _poolingObjects;

    private List<TPoolingObject> _pool = new List<TPoolingObject>();

    protected IReadOnlyList<TPoolingObject> Pool => _pool;

    private void Awake()
    {
        Initialize();
    }

    protected abstract void EnableObject(TPoolingObject poolingObject);
    protected abstract void DisableObject(TPoolingObject poolingObject);
    
    private void Initialize()
    {
        foreach (var obj in _poolingObjects)
        {
            if (!obj.Prefab.gameObject.TryGetComponent(out TPoolingObject poolingObject))
                throw new System.ArgumentException();

            for (int i = 0; i < obj.Capacity; i++)
            {
                GameObject spawned = Instantiate(obj.Prefab, _container.transform);
                spawned.SetActive(false);

                _pool.Add(spawned.gameObject.GetComponent<TPoolingObject>());
            }
        }
    }
}