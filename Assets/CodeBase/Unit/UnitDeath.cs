using System;
using CodeBase.Unit.Interface;
using UnityEngine;

namespace CodeBase.Unit
{
    [RequireComponent(typeof(IHealth))]
    public class UnitDeath : MonoBehaviour
    {
        [SerializeField] private UnitHealth _health;

        public event Action OnDeath;

        private void Start()
        {
            _health.OnHealthChanged += HealthChanged;
        }

        private void OnDestroy()
        {
            _health.OnHealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            if (_health.Current <= 0)
                Die();
        }

        private void Die()
        {
            _health.OnHealthChanged -= HealthChanged;
            OnDeath?.Invoke();
        }
    }
}