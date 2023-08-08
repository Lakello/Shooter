using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(ILevelStateRead))]
[RequireComponent(typeof(ILevelStateWrite))]
public class FightState : State
{
    private ILevelStateRead _stateRead;
    private ILevelStateWrite _stateWrite;
    private Spawner<Unit, UnitInfo> _spawner;
    private LevelInfo _levelInfo;
    private Coroutine _restartSpawnCoroutine;

    private void Awake()
    {
        _stateRead = GetComponent<ILevelStateRead>();
        _stateWrite = GetComponent<ILevelStateWrite>();
    }

    public override void Enter()
    {
        Debug.Log("FIGHT");

        RestartEnemySpawn();
    }

    public override void Exit()
    {
        Debug.Log("NON FIGHT");
    }

    private IEnumerator EnemySpawn()
    {
        Debug.Log($"Wave {_stateRead.CurrentWaveIndex}");
        Debug.Log($"Stage {_stateRead.CurrentStageIndex}");


        WaveStage currentStage = _levelInfo
                                .Waves[_stateRead.CurrentWaveIndex]
                                .Stages[_stateRead.CurrentStageIndex];

        WaitForSeconds delaybetweenSpawns 
            = new WaitForSeconds(currentStage.DelayBetweenSpawns);

        UnitInfo enemyInfo = currentStage.Enemy;

        int enemySpawned = 0;

        while (enemySpawned < currentStage.SpawnCount)
        {
            _spawner.OnSpawn(enemyInfo);
            enemySpawned++;

            yield return delaybetweenSpawns;
        }

        EndStage();
    }

    private void EndStage()
    {
        if (_stateWrite.TryNextStage())
            RestartEnemySpawn();
        else
            EndWave();
    }

    private void EndWave()
    {
        if (_stateWrite.TryNextWave())
            RestartEnemySpawn();
        else
            Transit();
    }

    private void RestartEnemySpawn()
    {
        if (_restartSpawnCoroutine != null)
            StopCoroutine(_restartSpawnCoroutine);

        _restartSpawnCoroutine = StartCoroutine(EnemySpawn());
    }

    private void Transit()
    {
        StateMachine.EnterIn<LevelCompletedState>();
    }

    [Inject]
    private void Init(Spawner<Unit, UnitInfo> spawner, LevelInfo levelInfo)
    {
        _spawner = spawner;
        _levelInfo = levelInfo;
    }
}