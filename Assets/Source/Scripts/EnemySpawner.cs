using UnityEngine;

public class EnemySpawner : Spawner<Unit, UnitInfo>
{
    private SpawnPoint[] _spawnPoints;

    public EnemySpawner(GameObject parent, ObjectFactory<Unit, UnitInfo> factory, ObjectPool<Unit, UnitInfo> pool) : base(factory, pool)
    {
        _spawnPoints = parent.GetComponentsInChildren<SpawnPoint>();
    }

    protected override Unit GetObject(UnitInfo info)
    {
        Unit obj = Pool.TryGetObject(info);

        if (obj == null)
        {
            obj = CreateObject(info);
        }

        return obj;
    }

    protected override Unit CreateObject(UnitInfo info)
    {
        Unit newUnit = Factory.GetNewObject(info);

        Pool.Add(info, newUnit);

        return newUnit;
    }
}
