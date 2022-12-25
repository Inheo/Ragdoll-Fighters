using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using CodeBase.Service.StaticData;
using UnityEngine;
using Zenject;

public class RegisterService : MonoInstaller
{
    [SerializeField] private JoystickInput _input;
    [SerializeField] private GameObject _levelStartButton;

    public override void InstallBindings()
    {
        BindJoystick();
        BindLevelStartButton();

        Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }

    public void BindJoystick()
    {
        var input = Container.InstantiatePrefabForComponent<JoystickInput>(_input);
        Container.Bind<JoystickInput>().FromInstance(input).AsSingle();
    }

    public void BindLevelStartButton()
    {
        var button = Container.InstantiatePrefabForComponent<LevelStartButton>(_levelStartButton);
        Container.Bind<LevelStartButton>().FromInstance(button).AsSingle();
    }
}