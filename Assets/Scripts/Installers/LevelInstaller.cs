using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Level _level;
    [SerializeField] private LevelStartButton _levelStartButton;
    [SerializeField] private JoystickInput _input;
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private EnemyFactory _enemyFactory;

    public override void InstallBindings()
    {
        LevelBind();
        JoystickBind();

        FactoriesBind();
    }

    private void FactoriesBind()
    {
        Container.Bind<PlayerFactory>().FromInstance(_playerFactory).AsSingle();
        Container.Bind<EnemyFactory>().FromInstance(_enemyFactory).AsSingle();
    }

    private void LevelBind()
    {
        Container.Bind<Level>().FromInstance(_level).AsSingle();
        Container.Bind<LevelStartButton>().FromInstance(_levelStartButton).AsSingle();
    }

    private void JoystickBind()
    {
        Container.Bind<JoystickInput>().FromInstance(_input).AsSingle();
    }
}