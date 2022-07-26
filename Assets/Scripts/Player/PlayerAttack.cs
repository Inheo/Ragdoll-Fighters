using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _attackReload = 1f;
    [SerializeField] private float _attackDistance = 2f;
    [SerializeField] private Transform _enemy;

    private float _timeLostLastAttack;
    private AnimatorTransition _animatorTransition;

    public void Initialize(AnimatorTransition animatorTransition)
    {
        _animatorTransition = animatorTransition;
    }

    private void Update()
    {
        _timeLostLastAttack += Time.deltaTime;

        if (_timeLostLastAttack > _attackReload && Vector3.Distance(transform.position, _enemy.position) < _attackDistance)
        {
            _timeLostLastAttack = 0;
            _animatorTransition.PlayRandomAttackState();

        }
    }
}