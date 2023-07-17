using UnityEngine;

[CreateAssetMenu(fileName = "newPoolingObject", menuName = "Pool/new Pooling Object")]
public class PoolingObject : ScriptableObject
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _capacity;

    public GameObject Prefab => _prefab;
    public int Capacity => _capacity;
}
