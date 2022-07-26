using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [System.Serializable]
    public struct Health
    {
        [SerializeField] private float _maxHealth;
        [HideInInspector] public float CurrentHealth;

        public float MaxHealth => _maxHealth;
    }

    [SerializeField] private Health _health;

    public event System.Action<Health> OnChangedHealth;
    public event System.Action OnDeath;

    public virtual void TakeDamage(int damage)
    {
        _health.CurrentHealth -= damage;
        _health.CurrentHealth = Mathf.Clamp(_health.CurrentHealth, 0, _health.MaxHealth);

        if (_health.CurrentHealth < 0)
            OnDeath?.Invoke();

        OnChangedHealth?.Invoke(_health);
    }
}