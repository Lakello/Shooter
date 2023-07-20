using UnityEngine;

public class EnemySpawner : ObjectsPool 
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private UnitsFactory _enemyUnitsFactory;

    private void Awake()
    {
        //_enemyUnitsFactory = new UnitsFactory();
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
    }


}
