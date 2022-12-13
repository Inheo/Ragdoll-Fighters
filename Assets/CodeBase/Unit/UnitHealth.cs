using System;
using UnityEngine;

public class UnitHealth : MonoBehaviour, IHealth
{
    private float _current;
    private float _max;

    public float Current
    {
        get => _current;
        set => _current = value;
    }
    public float Max
    {
        get => _max;
        set => _max = value;
    }

    public Unit Owner => null;

    public event Action OnHealthChanged;

    public void TakeDamage(float damage)
    {
        Current -= damage;
        OnHealthChanged?.Invoke();
    }
}