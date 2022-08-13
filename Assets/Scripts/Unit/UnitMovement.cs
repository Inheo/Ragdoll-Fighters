using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class UnitMovement : MonoBehaviour
{
    private MovementSettings _settings;

    private Rigidbody _rigidbody;
    private AnimatorTransition _animatorTransition;
    private ICanActionable _canActionable;

    [Inject]
    public void Construct(MovementSettings settings, AnimatorTransition animatorTransition, ICanActionable canActionable)
    {
        _settings = settings;
        _animatorTransition = animatorTransition;
        _canActionable = canActionable;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        
        if(_canActionable.IsCanAction() == false)
            Stop();
    }

    protected void Move(Vector2 direction)
    {
        if (_canActionable.IsCanAction() == false)
            return;

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