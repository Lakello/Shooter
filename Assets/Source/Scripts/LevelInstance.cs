using UnityEngine;
using System;

public class LevelInstance : MonoBehaviour
{
    [SerializeField] private LevelInfo _info;

    private LevelStateMachine _levelStateMachine;
    private EnemySpawner _enemySpawner;
    private Level _level;

    private void Awake()
    {
        _enemySpawner = new EnemySpawner(gameObject, new UnitsFactory(), new UnitPool());
        
        _levelStateMachine = new LevelStateMachine(_info);

        _level = new Level(_info, _levelStateMachine);
    }

    private void OnEnable()
    {
        _level.SpawnEnemy += _enemySpawner.OnSpawn;
    }

    private void OnDisable()
    {
        
    }
}
