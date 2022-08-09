using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class UnitMovement : MonoBehaviour
{
    private MovementSettings _settings;

    private Rigidbody _rigidbody;
    private AnimatorTransition _animatorTransition;

    [Inject]
    public void Construct(MovementSettings settings, AnimatorTransition animatorTransition)
    {
        _settings = settings;
        _animatorTransition = animatorTransition;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }

    protected void Move(Vector2 direction)
    {
        _rigidbody.velocity = Vector3.right * direction * _settings.Speed;

        if (direction.x > 0)
        {
            _animatorTransition.RunForward();
        }
        else if (direction.x < 0)
        {
            _animatorTransition.RunBack();
        }
    }

    protected void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
        _animatorTransition.Idle();
    }
}