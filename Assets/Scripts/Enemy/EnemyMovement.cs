using UnityEngine;
using Zenject;

public class EnemyMovement : UnitMovement, ITargetSetHandler
{
    [SerializeField] private float _stopDistance = 1f;
    private Unit _target;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void GetTargetSetEmitter(ITargetSetEmitter targetSetEmitter)
    {
        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;
    }

    private void OnDestroy()
    {
        TargetSetEmitter.OnSetTarget -= SetTarget;   
    }

    protected override void Update()
    {
        base.Update();

        if (Vector3.Distance(transform.position, _target.transform.position) > _stopDistance)
        {
            Vector2 direction = (_target.transform.position - transform.position).normalized;
            Move(direction);
        }
        else
        {
            Stop();
        }
    }

    public void SetTarget(Unit target)
    {
        _target = target;
    }
}