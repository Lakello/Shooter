using UnityEngine;
using Zenject.SpaceFighter;

public class EnemySpawner : Spawner<Unit>
{
    private SpawnPoint[] _spawnPoints;

    public EnemySpawner(GameObject spawnPointsContainer, ObjectFactory<Unit> factory, ObjectPool<Unit> pool) : base(factory, pool)
    {
        _spawnPoints = spawnPointsContainer.GetComponentsInChildren<SpawnPoint>();
    }

    public override void OnSpawn(Unit unit)
    {
        Unit spawnedUnit = GetObject(unit);

        int randomSpawnPointindex = Random.Range(0, _spawnPoints.Length);
        Vector3 position = _spawnPoints[randomSpawnPointindex].transform.position;

        spawnedUnit.Dead += Pool.Return;

        spawnedUnit.transform.position = position;
        spawnedUnit.gameObject.SetActive(true);
    }

    protected override Unit GetObject(Unit unit)
    {
        Unit spawnedUnit = Pool.TryGetObject(unit) ?? CreateObject(unit);

        return spawnedUnit;
    }

    protected override Unit CreateObject(Unit unit)
    {
        Debug.Log("Создан новый");
        Unit newUnit = Factory.GetNewObject(unit);

        return newUnit;
    }
}
