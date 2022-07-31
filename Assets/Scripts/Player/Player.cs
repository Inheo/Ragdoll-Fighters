using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class Player : Unit
{
    [SerializeField] private Animator _animator;

    private PlayerMovement _movement;
    private PlayerAttack _attack;

    private AnimatorTransition _animatorTransition;

    protected override void Awake()
    {
        base.Awake();
        
        _movement = GetComponent<PlayerMovement>();
        _attack = GetComponent<PlayerAttack>();

        _animatorTransition = new AnimatorTransition(_animator);
    }

    private void Start()
    {
        _movement.Initialize(_animatorTransition);
        _attack.Initialize(_animatorTransition);
    }
}