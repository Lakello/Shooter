using UnityEngine;
using System;

[Serializable]
public class WaveStage
{
    [SerializeField] private float _delayBetweenSpawns;
    [SerializeField] private Unit _enemyPrefab;
    [SerializeField] private int _count;

    public float DelayBetweenSpawns => _delayBetweenSpawns;
    public Unit Enemy => _enemyPrefab;
    public int SpawnCount => _count;
}
