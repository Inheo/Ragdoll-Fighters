using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private JoystickInput _input;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _input.OnActive += Move;
        _input.OnStop += Stop;
    }

    private void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    private void Move(Vector2 direction)
    {
        _rigidbody.velocity = Vector3.right * direction * _speed;
    }
}