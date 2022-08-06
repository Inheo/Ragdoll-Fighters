using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Level _level;

    public override void InstallBindings()
    {
        Container.Bind<Level>().FromInstance(_level).AsSingle();
    }
}