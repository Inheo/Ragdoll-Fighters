using UnityEngine;
using Zenject;

public class UnitInstaller : MonoInstaller
{
    [SerializeField] private Animator _animator;
    [SerializeField] private HealthSettings _health;
    [SerializeField] private AttackSettings _attack;
    [SerializeField] private MovementSettings _movement;

    public override void InstallBindings()
    {
        Container.Bind<Animator>().FromInstance(_animator).AsSingle();

        Container.Bind<HealthSettings>().FromInstance(_health).AsSingle();
        Container.Bind<AttackSettings>().FromInstance(_attack).AsSingle();
        Container.Bind<MovementSettings>().FromInstance(_movement).AsSingle();

        Container.Bind<AnimatorTransition>().FromNew().AsSingle();
    }
}