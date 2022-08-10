using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Level _level;
    [SerializeField] private JoystickInput _input;
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private EnemyFactory _enemyFactory;

    public override void InstallBindings()
    {
        Container.Bind<Level>().FromInstance(_level).AsSingle();
        
        Container.Bind<JoystickInput>().FromInstance(_input).AsSingle();

        Container.Bind<PlayerFactory>().FromInstance(_playerFactory).AsSingle();
        Container.Bind<EnemyFactory>().FromInstance(_enemyFactory).AsSingle();
    }
}