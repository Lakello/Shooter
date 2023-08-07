using UnityEngine;
using Zenject;
using System;
using System.Collections.Generic;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private GameObject _spawnPointsContainer;
    [SerializeField] private LevelInfo _info;

    private void OnValidate()
    {
        if (_info == null ||
            _spawnPointsContainer == null)
            throw new NullReferenceException();
    }

    public override void InstallBindings()
    {
        Container.Bind<MonoBehaviour>()
                 .FromMethod(() => this);

        Container.BindInterfacesTo<Timer>()
                 .AsSingle()
                 .NonLazy();

        Container.Bind<LevelInfo>().FromMethod(() => _info);

        Container.Bind<Spawner<Unit, UnitInfo>>()
                 .FromMethod(() => new EnemySpawner(_spawnPointsContainer, new UnitsFactory(), new UnitPool()))
                 .AsSingle()
                 .NonLazy();

        Container.Bind<TimeIsUpTransition>()
                 .AsSingle()
                 .NonLazy();

        LevelStateMachineInit();
    }

    private void LevelStateMachineInit()
    { 
        Container.Bind<IFirstState>()
                 .FromMethod(() => new PreparationState())
                 .AsSingle()
                 .NonLazy();

        Container.Bind<StateMachine>()
                 .FromMethod(() =>
                 {
                     return new LevelStateMachine(() =>
                     {
                         return new Dictionary<Type, State>()
                         {
                             [typeof(FightState)] = new FightState(),
                             [typeof(WaitingState)] = new WaitingState()
                         };
                     });
                 })
                 .AsSingle()
                 .NonLazy();
    }
}