using UnityEngine;
using System;

[Serializable]
public class WaveStage
{
    [SerializeField] private UnitType _enemy;
    [SerializeField] private int _count;

    public UnitType Enemy => _enemy;
    public int Count => _count;
}
