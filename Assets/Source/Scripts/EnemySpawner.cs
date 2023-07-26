using UnityEngine;

public class EnemySpawner : Spawner<Unit, UnitInfo>
{
    private SpawnPoint[] _spawnPoints;

    public EnemySpawner(GameObject parent, ObjectFactory<Unit, UnitInfo> factory, ObjectPool<Unit, UnitInfo> pool) : base(factory, pool)
    {
        _spawnPoints = parent.GetComponentsInChildren<SpawnPoint>();
    }

    public override void OnSpawn(UnitInfo info)
    {
        Unit unit = GetObject(info);

        int randomSpawnPointindex = Random.Range(0, _spawnPoints.Length);
        Vector3 position = _spawnPoints[randomSpawnPointindex].transform.position;

        unit.transform.position = position;
        unit.gameObject.SetActive(true);
    }

    protected override Unit GetObject(UnitInfo info)
    {
        Unit unit = Pool.TryGetObject(info);

        if (unit == null)
        {
            unit = CreateObject(info);
        }

        return unit;
    }

    protected override Unit CreateObject(UnitInfo info)
    {
        Unit newUnit = Factory.GetNewObject(info);

        Pool.Add(newUnit);

        return newUnit;
    }
}
