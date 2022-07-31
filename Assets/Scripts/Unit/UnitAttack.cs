using System.Collections.Generic;
using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private float _attackReload = 1f;
    [SerializeField] private float _attackDistance = 2f;
    [SerializeField] private Transform _enemy;

    private float _timeLostLastAttack;
    private AnimatorTransition _animatorTransition;

    private List<Weapon> _weapons;

    public void Initialize(AnimatorTransition animatorTransition)
    {
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

        if (_timeLostLastAttack > _attackReload && Vector3.Distance(transform.position, _enemy.position) < _attackDistance)
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