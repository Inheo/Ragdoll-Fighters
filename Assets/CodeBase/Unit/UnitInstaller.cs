using CodeBase.Unit.Interfaces;
using UnityEngine;
using Zenject;
using CodeBase.Unit.Settings;

namespace CodeBase.Unit
{
    public class UnitInstaller : MonoInstaller
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Unit _owner;
        [SerializeField] private HealthSettings _health;
        [SerializeField] private AttackSettings _attack;
        [SerializeField] private MovementSettings _movement;

        public override void InstallBindings()
        {
            BindAnimator();
            BindOwner();
            BindUnitSettings();
        }

        private void BindUnitSettings()
        {
            Container.Bind<HealthSettings>().FromInstance(_health).AsSingle();
            Container.Bind<AttackSettings>().FromInstance(_attack).AsSingle();
            Container.Bind<MovementSettings>().FromInstance(_movement).AsSingle();
        }

        private void BindAnimator()
        {
            Container.Bind<Animator>().FromInstance(_animator).AsSingle();
            Container.Bind<AnimatorTransition>().AsSingle();
        }
        private void BindOwner()
        {
            Container.Bind<Unit>().FromInstance(_owner).AsSingle();
            Container.Bind<ITargetSetEmitter>().FromInstance(_owner).AsSingle();
            Container.Bind<ICanActionable>().FromInstance(_owner).AsSingle();
        }
    }
}