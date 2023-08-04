using UnityEngine;
using Zenject;
using System;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelInfo _info;

    private void OnValidate()
    {
        if (_info == null)
            throw new NullReferenceException(nameof(LevelInfo));
    }

    public override void InstallBindings()
    {
        Container.Bind<MonoBehaviour>().FromMethod(GetMonoBehaviour).AsSingle();
        Container.Bind(typeof(ITimeRead), typeof(ITimeWrite)).To<Timer>().AsSingle();

        LevelStateMachineInit();
    }

    private void LevelStateMachineInit()
    {
        Container.Bind<LevelInfo>().FromMethod(GetLevelInfo).AsSingle();
        Container.Bind<LevelStateMachine>().AsSingle().NonLazy();
    }

    private LevelInfo GetLevelInfo(InjectContext ctx) => _info;
    private MonoBehaviour GetMonoBehaviour(InjectContext ctx) => this;
}