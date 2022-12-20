using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Factory;
using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using CodeBase.Service.StaticData;
using Zenject;

public class RegisterService : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
        Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
        Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
        Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
    }
}