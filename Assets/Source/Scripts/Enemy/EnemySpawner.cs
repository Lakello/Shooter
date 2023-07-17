using UnityEngine;

public class EnemySpawner : ObjectsPool<Enemy>
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }

    protected override void DisableObject(Enemy poolingObject)
    {
        throw new System.NotImplementedException();
    }

    protected override void EnableObject(Enemy poolingObject)
    {
        throw new System.NotImplementedException();
    }
}
