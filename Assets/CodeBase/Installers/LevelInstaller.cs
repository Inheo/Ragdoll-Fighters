using UnityEngine;
using Zenject;

public class LevelInstaller : MonoInstaller
{
    [SerializeField] private Level _level;
    [SerializeField] private LevelStartButton _levelStartButton;
    [SerializeField] private JoystickInput _input;

    public override void InstallBindings()
    {
        LevelBind();
        JoystickBind();
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