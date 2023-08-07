using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LevelStateMachine : StateMachine, ILevelState
{
    private LevelInfo _levelInfo;
    private int _currentWave;
    private int _currentWaveStage;

    public int CurrentWave => _currentWave;
    public int CurrentWaveStage => _currentWaveStage;

    public LevelStateMachine(Func<Dictionary<Type, State>> states) : base(states) {}

    public void NextWave()
    {
        if (CurrentWave < _levelInfo.Waves.Count)
            _currentWave++;
    }

    public void NextWaveStage()
    {
        if (CurrentWaveStage < _levelInfo.Waves[CurrentWave - 1].Stages.Count)
            _currentWave++;
    }

    [Inject]
    private void Init(LevelInfo levelInfo) => _levelInfo = levelInfo;
}
