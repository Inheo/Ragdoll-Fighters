using UnityEngine;

namespace CodeBase.Unit.Settings
{
    [System.Serializable]
    public struct HealthSettings
    {
        [SerializeField] private float _health;
        [HideInInspector] public float CurrentHealth;

        public float StartHealth => _health;

        public void Initialize()
        {
            CurrentHealth = _health;
        }

        public HealthSettings(float health)
        {
            _health = health;
            CurrentHealth = health;
            Debug.Log($"{health}");
        }
    }
}