using UnityEngine;

public class TakeDamageHandler : MonoBehaviour, ITakeDamage
{
    private UnitHealth _unit;

    public Unit Owner { get; private set; }

    private void Start()
    {
        Owner = GetComponentInParent<Unit>();
        _unit = GetComponentInParent<UnitHealth>();
    }

    public void TakeDamage(float damage)
    {
        _unit.TakeDamage(damage);
    }
}