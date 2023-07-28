using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private LevelInfo _info;

    public override void InstallBindings()
    {
    }
}