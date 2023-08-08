using UnityEngine;
using System;

[Serializable]
public class WaveStage
{
    [SerializeField] private float _delayBetweenSpawns;
    [SerializeField] private UnitInfo _enemy;
    [SerializeField] private int _count;

    public float DelayBetweenSpawns => _delayBetweenSpawns;
    public UnitInfo Enemy => _enemy;
    public int SpawnCount => _count;
}
