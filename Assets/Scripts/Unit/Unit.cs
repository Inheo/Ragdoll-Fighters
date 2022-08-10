using System;
using UnityEngine;
using Zenject;

public abstract class Unit : MonoBehaviour, ITakeDamage, ITargetSetEmitter
{
    [SerializeField] private HealthSettings _health;
    [SerializeField] private Animator _animator;

    public Unit Owner => this;

    public event System.Action<HealthSettings> OnChangedHealth;
    public event System.Action OnDeath;
    public event Action<Unit> OnSetTarget;

    [Inject]
    public void Construct(HealthSettings health, Animator animator)
    {
        _health = health;
        _animator = animator;
    }

    public virtual void Initialize()
    {
        _health.Initialize();
    }

    protected TargetType FindTarget<TargetType>() where TargetType : Unit
    {
        var target = FindObjectOfType<TargetType>();
        OnSetTarget?.Invoke(target);

        return target;
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