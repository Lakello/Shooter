using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectsPool<TPoolingObject> : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capacity;

    private List<TPoolingObject> _pool = new List<TPoolingObject>();

    protected IReadOnlyList<TPoolingObject> Pool => _pool;

    private void Awake()
    {
        Initialize(_prefab);
    }

    protected abstract void EnableObject(TPoolingObject poolingObject);
    protected abstract void DisableObject(TPoolingObject poolingObject);
    
    private void Initialize(GameObject prefab)
    {
        if (!prefab.gameObject.TryGetComponent(out TPoolingObject poolingObject))
            throw new System.ArgumentException();

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned.gameObject.GetComponent<TPoolingObject>());
        }
    }
}