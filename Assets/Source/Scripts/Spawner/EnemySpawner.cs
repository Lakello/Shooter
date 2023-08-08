using UnityEngine;
using Zenject.SpaceFighter;

public class EnemySpawner : Spawner<Unit, UnitInfo>
{
    private SpawnPoint[] _spawnPoints;

    public EnemySpawner(GameObject spawnPointsContainer, ObjectFactory<Unit, UnitInfo> factory, ObjectPool<Unit, UnitInfo> pool) : base(factory, pool)
    {
        _spawnPoints = spawnPointsContainer.GetComponentsInChildren<SpawnPoint>();
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
        Unit unit = Pool.TryGetObject(info) ?? CreateObject(info);

        return unit;
    }

    protected override Unit CreateObject(UnitInfo info)
    {
        Debug.Log($"enemy Spawned");
        Unit newUnit = Factory.GetNewObject(info);

        return newUnit;
    }
}
