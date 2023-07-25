using UnityEngine;
using System;

[Serializable]
public class WaveStage
{
    [SerializeField] private UnitInfo _enemy;
    [SerializeField] private int _count;

    public UnitInfo Enemy => _enemy;
    public int Count => _count;
}
