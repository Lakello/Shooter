using UnityEngine;
using System;

[Serializable]
public class WaveStage
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _count;

    public Enemy Enemy => _enemy;
    public int Count => _count;
}
