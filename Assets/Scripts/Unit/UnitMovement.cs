using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class UnitMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private AnimatorTransition _animatorTransition;

    public void Initialize(AnimatorTransition animatorTransition)
    {
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

    protected void Stop()
    {
        _rigidbody.velocity = Vector3.zero;
        _animatorTransition.Idle();
    }
}