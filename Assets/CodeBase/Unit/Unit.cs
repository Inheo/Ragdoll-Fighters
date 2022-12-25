using System;
using UnityEngine;

public abstract class Unit : MonoBehaviour, ITargetSetEmitter, ICanActionable
{
    public event Action<Unit> OnSetTarget;

    protected TargetType FindTarget<TargetType>() where TargetType : Unit
    {
        var target = FindObjectOfType<TargetType>();

        if (target != null)
            OnSetTarget?.Invoke(target);

        return target;
    }

    public void SetTarget(Unit target)
    {
        if (target == null)
            return;
            
        OnSetTarget?.Invoke(target);
    }

    public bool IsCanAction() => Level.Instance.IsLevelEnd == false;
}