using UnityEngine;
using Zenject;

public class UnitRotator : MonoBehaviour, ITargetSetHandler
{
    [SerializeField] protected Unit _target;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void GetTargetSetEmitter(ITargetSetEmitter targetSetEmitter)
    {
        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;
    }

    public void SetTarget(Unit target)
    {
        _target = target;
    }

    private void Update()
    {
        Vector3 direction = _target.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}