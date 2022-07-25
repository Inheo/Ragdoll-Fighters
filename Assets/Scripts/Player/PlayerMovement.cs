using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private JoystickInput _input;
    [SerializeField] private Animator _animator;

    private Rigidbody _rigidbody;
    private AnimatorTransition _animatorTransition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animatorTransition = new AnimatorTransition(_animator);
    }

    private void Start()
    {
        _input.OnActive += Move;
        _input.OnStop += Stop;
    }

    private void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
        _animatorTransition.Idle();
    }

    private void Move(Vector2 direction)
    {
        _rigidbody.velocity = Vector3.right * direction * _speed;

        if (direction.x > 0)
        {
            _animatorTransition.RunForward();
        }
        else if (direction.x < 0)
        {
            _animatorTransition.RunBack();
        }
    }
}