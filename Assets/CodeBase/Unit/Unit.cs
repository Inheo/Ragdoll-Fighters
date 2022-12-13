using System;
using UnityEngine;
using Zenject;

public abstract class Unit : MonoBehaviour, ITargetSetEmitter, ICanActionable
{
    private Level _level;

    public event Action<Unit> OnSetTarget;

    [Inject]
    public void Construct(Level level)
    {
        _level = level;
    }

    protected TargetType FindTarget<TargetType>() where TargetType : Unit
    {
        var target = FindObjectOfType<TargetType>();
        OnSetTarget?.Invoke(target);

        return target;
    }

    public bool IsCanAction() => _level.IsLevelEnd == false;
}