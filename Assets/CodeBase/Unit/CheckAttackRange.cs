using UnityEngine;
using Zenject;

[RequireComponent(typeof(IAttack))]
public class CheckAttackRange : MonoBehaviour, ITargetSetHandler
{
    public float Distance;
    public IAttack Attack;
    private Transform _target;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void Construct(ITargetSetEmitter targetSetEmitter)
    {
        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;
    }

    private void OnDestroy()
    {
        TargetSetEmitter.OnSetTarget -= SetTarget;
    }

    public void SetTarget(Unit target)
    {
        _target = target.transform;
    }

    private void Start()
    {
        Attack = Attack == null ? GetComponentInChildren<IAttack>() : Attack;
        Attack.DisableAttack();
    }

    private void Update()
    {
        if (_target != null && Vector3.Distance(transform.position, _target.position) <= Distance)
            Attack.EnableAttack();
        else
            Attack.DisableAttack();
    }
}
