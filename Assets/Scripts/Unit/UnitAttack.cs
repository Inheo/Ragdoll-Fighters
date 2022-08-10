using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitAttack : MonoBehaviour, ITargetSetHandler
{
    [SerializeField] protected Unit _target;

    private float _timeLostLastAttack;

    private AttackSettings _attackSettings;
    private AnimatorTransition _animatorTransition;

    private List<Weapon> _weapons;

    public ITargetSetEmitter TargetSetEmitter { get; private set; }

    [Inject]
    public void Construct(AttackSettings attackSettings, AnimatorTransition animatorTransition, ITargetSetEmitter targetSetEmitter)
    {
        _attackSettings = attackSettings;
        _animatorTransition = animatorTransition;
    }

    [Inject]
    public void GetTargetSetEmitter(ITargetSetEmitter targetSetEmitter)
    {
        TargetSetEmitter = targetSetEmitter;
        TargetSetEmitter.OnSetTarget += SetTarget;
    }

    private void Start()
    {
        _weapons = new List<Weapon>(GetComponentsInChildren<Weapon>());

        Unit owner = GetComponent<Unit>();

        for (var i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].Initialize(owner);
        }
    }

    private void OnDestroy()
    {
        TargetSetEmitter.OnSetTarget -= SetTarget;
    }

    private void Update()
    {
        _timeLostLastAttack += Time.deltaTime;

        if (_timeLostLastAttack > _attackSettings.Reload && Vector3.Distance(transform.position, _target.transform.position) < _attackSettings.Distance)
        {
            _timeLostLastAttack = 0;
            _animatorTransition.PlayRandomAttackState();

            ActiveWeapons();
        }
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