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
    }

    private void Update()
    {
        _timeLostLastAttack += Time.deltaTime;

        if (_timeLostLastAttack > _attackReload && Vector3.Distance(transform.position, _enemy.position) < _attackDistance)
        {
            _timeLostLastAttack = 0;
            _animatorTransition.PlayRandomAttackState();

            for (var i = 0; i < _weapons.Count; i++)
            {
                _weapons[i].Active();
            }
        }
    }

    public void AttackPlayEnded()
    {
        _animatorTransition.AttackLayerDisable();

        for (var i = 0; i < _weapons.Count; i++)
        {
            _weapons[i].Deactive();
        }
    }
}