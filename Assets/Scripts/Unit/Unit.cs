using System;
using UnityEngine;
using Zenject;

public abstract class Unit : MonoBehaviour, ITakeDamage, ITargetSetEmitter, ICanActionable
{
    private HealthSettings _health;
    private Animator _animator;
    private Level _level;

    public Unit Owner => this;

    public event System.Action<HealthSettings> OnChangedHealth;
    public event System.Action<float> OnTakedDamage;
    public event System.Action OnDeath;
    public event Action<Unit> OnSetTarget;

    [Inject]
    public void Construct(HealthSettings health, Animator animator, Level level)
    {
        _health = health;
        _animator = animator;
        _level = level;
    }

    protected virtual void Start()
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
        OnTakedDamage?.Invoke(damage);
    }

    public bool IsCanAction() => _level.IsLevelEnd == false;
}