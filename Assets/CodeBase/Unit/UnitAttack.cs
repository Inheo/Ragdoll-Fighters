using System.Collections.Generic;
using CodeBase.Unit.Interfaces;
using UnityEngine;
using Zenject;
using WeaponBase = CodeBase.Weapon.Weapon;

namespace CodeBase.Unit
{
    public class UnitAttack : MonoBehaviour, IAttack
    {
        public float AttackCooldown { get; set; } = 3.0f;
        public float Damage { get; set; } = 1;

        private float _attackCooldown;

        private AnimatorTransition _animatorTransition;
        private ICanActionable _canActionable;
        private Unit _owner;
        private bool _attackIsActive;

        private List<WeaponBase> _weapons;

        [Inject]
        public void Construct(AnimatorTransition animatorTransition, ICanActionable canActionable, Unit owner)
        {
            _animatorTransition = animatorTransition;
            _canActionable = canActionable;
            _owner = owner;
        }

        private void Start()
        {
            GetWeapons();
            WeaponsInitialize();
        }

        private void Update()
        {
            UpdateCooldown();

            if (CanAttack())
                StartAttack();
        }

        private void StartAttack()
        {
            _attackCooldown = 0;
            _animatorTransition.PlayRandomAttackState();
            ActiveWeapons();
        }

        public void AttackPlayEnded()
        {
            _animatorTransition.AttackLayerDisable();
            DeactiveWeapons();
        }

        public void EnableAttack() =>
            _attackIsActive = true;

        public void DisableAttack() =>
            _attackIsActive = false;

        private void WeaponsInitialize()
        {
            for (var i = 0; i < _weapons.Count; i++)
            {
                _weapons[i].Initialize(_owner);
            }
        }

        private void GetWeapons()
        {
            _weapons = new List<WeaponBase>(GetComponentsInChildren<WeaponBase>());
        }

        private bool CanAttack()
        {
            return CooldownIsUp() && _attackIsActive && _canActionable.IsCanAction();
        }

        private void UpdateCooldown()
        {
            if (!CooldownIsUp())
                _attackCooldown -= Time.deltaTime;
        }

        private bool CooldownIsUp() =>
            _attackCooldown <= 0;

        private void ActiveWeapons()
        {
            for (var i = 0; i < _weapons.Count; i++)
            {
                _weapons[i].Active();
            }
        }

        private void DeactiveWeapons()
        {
            for (var i = 0; i < _weapons.Count; i++)
            {
                _weapons[i].Deactive();
            }
        }
    }
}