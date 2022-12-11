using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [System.Flags]
    public enum FollowAxis
    {
        X = 1,
        Y = 2,
        Z = 4
    }

    [SerializeField, Min(0.01f)] private float _speed = 1f;
    [SerializeField] private Transform _target;
    [SerializeField] private FollowAxis _followAxis = FollowAxis.X | FollowAxis.Y | FollowAxis.Z;

    private Vector3 _offset;

    private void Start()
    {
        _offset = _target.position - transform.position;
    }

    private void LateUpdate()
    {
        Vector3 newPosition = _target.position - _offset;
        newPosition.x = (_followAxis & FollowAxis.X) == FollowAxis.X ? newPosition.x : transform.position.x;
        newPosition.y = (_followAxis & FollowAxis.Y) == FollowAxis.Y ? newPosition.y : transform.position.y;
        newPosition.z = (_followAxis & FollowAxis.Z) == FollowAxis.Z ? newPosition.z : transform.position.z;

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * _speed);
    }
}