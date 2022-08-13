using UnityEngine;
using Zenject;

public class UnitRotator : MonoBehaviour, ITargetSetHandler
{
    protected Unit _target;

    private ICanActionable _canActionable;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void Construct(ICanActionable canActionable, ITargetSetEmitter targetSetEmitter)
    {
        _canActionable = canActionable;

        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;
    }

    public void SetTarget(Unit target)
    {
        _target = target;
    }

    private void Update()
    {
        if (_canActionable.IsCanAction() == false)
            return;

        Vector3 direction = _target.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}