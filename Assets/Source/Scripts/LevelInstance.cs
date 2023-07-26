using UnityEngine;
using System;

public class LevelInstance : MonoBehaviour
{
    [SerializeField] private LevelInfo _info;

    private Spawner<Unit, UnitInfo> _enemySpawner;
    private Level _level;

    private void Awake()
    {
        _enemySpawner = new EnemySpawner(gameObject, new UnitsFactory(), new UnitPool());

        _level = new Level(_info);
    }

    private void OnEnable()
    {
        _level.SpawnEnemy += _enemySpawner.OnSpawn;
    }

    private void OnDisable()
    {
        _level.SpawnEnemy -= _enemySpawner.OnSpawn;
    }
}
