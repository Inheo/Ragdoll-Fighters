using UnityEngine;

public abstract class Unit : MonoBehaviour, ITakeDamage
{
    [System.Serializable]
    public struct Health
    {
        [SerializeField] private float _health;
        [SerializeField] public float CurrentHealth;

        public float StartHealth => _health;

        public void Initialize()
        {
            CurrentHealth = _health;
        }
    }

    [SerializeField] private Health _health;

    public Unit Owner => this;

    public event System.Action<Health> OnChangedHealth;
    public event System.Action OnDeath;

    protected virtual void Awake()
    {
        _health.Initialize();
    }

    public virtual void TakeDamage(float damage)
    {
        _health.CurrentHealth -= damage;
        _health.CurrentHealth = Mathf.Clamp(_health.CurrentHealth, 0, _health.StartHealth);

        if (_health.CurrentHealth < 0)
            OnDeath?.Invoke();

        OnChangedHealth?.Invoke(_health);
    }
}