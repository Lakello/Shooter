using UnityEngine;
using Zenject;
using System;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _spawnPointsContainer;
    [SerializeField] private LevelInfo _info;

    private void OnValidate()
    {
        if (_info == null ||
            _spawnPointsContainer == null ||
            _player == null)
            throw new NullReferenceException();
    }

    public override void InstallBindings()
    {
        Container.Bind<PlayerInput>()
                 .AsSingle()
                 .NonLazy();

        Container.Bind<MonoBehaviour>()
                 .FromMethod(() => this);

        Container.BindInterfacesTo<Timer>()
                 .AsSingle()
                 .NonLazy();

        Container.Bind<LevelInfo>().FromMethod(() => _info);

        Container.Bind<Spawner<Unit>>()
                 .FromMethod(() => new EnemySpawner(_spawnPointsContainer, new UnitsFactory(_player), new UnitPool()))
                 .AsSingle()
                 .NonLazy();

        Container.Bind<TimeIsUpTransition>()
                 .AsSingle()
                 .NonLazy();
    }
}