using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WaveSpawnState : State
{
    private Spawner<Unit, UnitInfo> _spawner;

    [Inject]
    private void Init(Spawner<Unit, UnitInfo> spawner)
    {
        _spawner = spawner;
    }

    public override void Enter()
    {
        enabled = true;
        Debug.Log("FIGHT");
    }

    public override void Exit()
    {
        enabled = false;
        Debug.Log("NON FIGHT");
    }
}