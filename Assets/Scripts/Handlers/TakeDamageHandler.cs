using UnityEngine;

public class TakeDamageHandler : MonoBehaviour, ITakeDamage
{
    private Unit _unit;

    public Unit Owner => _unit;

    private void Start()
    {
        _unit = GetComponentInParent<Unit>();
    }

    public void TakeDamage(float damage)
    {
        _unit.TakeDamage(damage);
    }
}