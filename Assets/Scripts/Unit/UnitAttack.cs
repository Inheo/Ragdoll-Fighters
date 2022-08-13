using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitAttack : MonoBehaviour, ITargetSetHandler
{
    protected Unit _target;

    private float _timeLostLastAttack;

    private AttackSettings _attackSettings;
    private AnimatorTransition _animatorTransition;
    private ICanActionable _canActionable;
    private Unit _owner;

    private List<Weapon> _weapons;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void Construct(AttackSettings attackSettings,
                            AnimatorTransition animatorTransition,
                            ITargetSetEmitter targetSetEmitter,
                            ICanActionable canActionable,
                            Unit owner)
    {
        _attackSettings = attackSettings;
        _animatorTransition = animatorTransition;
        _canActionable = canActionable;

        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;

        _owner = owner;
    }

    private void Start()
    {
        GetWeapons();
        WeaponsInitialize();
    }

    private void OnDestroy()
    {
        TargetSetEmitter.OnSetTarget -= SetTarget;
    }

    private void Update()
    {
        _timeLostLastAttack += Time.deltaTime;

        if (AttackConditions())
        {
            _timeLostLastAttack = 0;
            _animatorTransition.PlayRandomAttackState();

            ActiveWeapons();
        }
    }

    private void WeaponsInitialize()
    {
        for (var i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].Initialize(_owner);
        }
    }

    private void GetWeapons()
    {
        _weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());
    }

    private bool AttackConditions()
    {
        bool isReloaded = _timeLostLastAttack > _attackSettings.Reload;
        bool isTargetNear = Vector3.Distance(transform.position, _target.transform.position) < _attackSettings.Distance;

        return isReloaded && isTargetNear && _canActionable.IsCanAction();
    }

    private void ActiveWeapons()
    {
        for (var i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].Active();
        }
    }

    private void DeactiveWeapons()
    {
        for (var i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].Deactive();
        }
    }

    public void AttackPlayEnded()
    {
        _animatorTransition.AttackLayerDisable();

        DeactiveWeapons();
    }

    public void SetTarget(Unit target)
    {
        _target = target;
    }
}