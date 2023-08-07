using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FightState : State
{
    private Spawner<Unit, UnitInfo> _spawner;
    private LevelInfo _levelInfo;

    [Inject]
    private void Init(Spawner<Unit, UnitInfo> spawner, LevelInfo levelInfo)
    {
        _spawner = spawner;
        _levelInfo = levelInfo;
    }

    public override void Enter()
    {
        Debug.Log("FIGHT");
    }

    public override void Exit()
    {
        Debug.Log("NON FIGHT");
    }
}