using UnityEngine;
using Zenject;

[RequireComponent(typeof(ConfigurableJoint))]
public class PhysicRotationTo : MonoBehaviour, ITargetSetHandler
{
    private Transform _target;

    private ConfigurableJoint _pelvisJoint;
    private ICanActionable _canActionable;

    private Quaternion _startRotation;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void Construct(ICanActionable canActionable, ITargetSetEmitter targetSetEmitter)
    {
        _canActionable = canActionable;

        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;
    }

    private void Awake()
    {
        _startRotation = transform.rotation;
        _pelvisJoint = GetComponent<ConfigurableJoint>();
    }

    private void OnDestroy()
    {
        TargetSetEmitter.OnSetTarget -= SetTarget;
    }

    private void FixedUpdate()
    {
        if (_canActionable.IsCanAction() == false)
            return;
            
        Vector3 direction = _target.position - transform.position;
        direction.y = 0;
        _pelvisJoint.targetRotation = Quaternion.Inverse(Quaternion.LookRotation(direction)) * _startRotation;
    }

    public void SetTarget(Unit target)
    {
        _target = target.transform;
    }
}