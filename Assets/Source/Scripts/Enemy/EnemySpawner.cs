using UnityEngine;

public class EnemySpawner : Spawner<Unit, UnitInfo>
{
    [SerializeField] private SpawnPoint[] _spawnPoints;

    private PoolInit<Unit, UnitInfo> _pool;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _pool = new PoolInit<Unit, UnitInfo>(new UnitsFactory(), new UnitPoolList());
    }

    protected override Unit GetObject(UnitInfo info)
    {
        Unit obj = _pool.PoolList.TryGetObject(info);

        if (obj == null)
        {
            obj = CreateObject(info);
        }

        return obj;
    }

    protected override Unit CreateObject(UnitInfo info)
    {
        Unit newUnit = _pool.UnitsFactory.GetNewObject(info);

        _pool.PoolList.Add(info, newUnit);

        return newUnit;
    }
}
