using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public class PhysicRotationTo : MonoBehaviour
{
    [SerializeField] private Transform _to;

    private ConfigurableJoint _pelvisJoint;

    private Quaternion _startRotation;

    private void Awake()
    {
        _startRotation = transform.rotation;
        _pelvisJoint = GetComponent<ConfigurableJoint>();
    }

    private void FixedUpdate()
    {
        Vector3 direction = _to.position - transform.position;
        direction.y = 0;
        _pelvisJoint.targetRotation = Quaternion.Inverse(Quaternion.LookRotation(direction)) * _startRotation;
    }
}