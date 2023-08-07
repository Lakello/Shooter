using UnityEngine;
using Zenject;
using System;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelStateMachine _levelStateMachine;
    [SerializeField] private GameObject _spawnPointsContainer;
    [SerializeField] private LevelInfo _info;

    private void OnValidate()
    {
        if (_info == null ||
            _spawnPointsContainer == null ||
            _levelStateMachine == null)
            throw new NullReferenceException();
    }

    public override void InstallBindings()
    {
        Container.Bind<MonoBehaviour>().FromMethod(GetMonoBehaviour);
        Container.BindInterfacesTo<Timer>().AsSingle().NonLazy();

        Container.Bind<LevelInfo>().FromMethod(GetLevelInfo);
        Container.Bind<Spawner<Unit, UnitInfo>>().FromMethod(GetEnemySpawner).AsSingle().NonLazy();

        Container.BindInterfacesTo<LevelStateMachine>().FromMethod(GetLevelStateMachine);
    }

    private LevelStateMachine GetLevelStateMachine(InjectContext ctx) => _levelStateMachine;
    private EnemySpawner GetEnemySpawner(InjectContext ctx) => new(_spawnPointsContainer, new UnitsFactory(), new UnitPool());
    private LevelInfo GetLevelInfo(InjectContext ctx) => _info;
    private MonoBehaviour GetMonoBehaviour(InjectContext ctx) => this;
}