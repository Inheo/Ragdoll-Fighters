using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private Unit _target;

    private AttackSettings _attackSettings;

    private float _timeLostLastAttack;
    private AnimatorTransition _animatorTransition;

    private List<Weapon> _weapons;

    [Zenject.Inject]
    public void Construct(AttackSettings attackSettings, AnimatorTransition animatorTransition)
    {
        _attackSettings = attackSettings;
        _animatorTransition = animatorTransition;
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
}