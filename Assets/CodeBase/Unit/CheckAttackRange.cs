using UnityEngine;

[RequireComponent(typeof(IAttack))]
public class CheckAttackRange : MonoBehaviour
{
    public float Distance;
    public Transform target;
    public IAttack Attack;

    private void Start()
    {
        Attack.DisableAttack();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= Distance)
        {
            Attack.EnableAttack();
        }
        else
        {
            Attack.DisableAttack();
        }
    }
}
