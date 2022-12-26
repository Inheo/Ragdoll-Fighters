using UnityEngine;

namespace CodeBase.Unit
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class RotationCopyrator : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private ConfigurableJoint _configurableJoint;
        private Quaternion _startRotation;

        private void Awake()
        {
            _configurableJoint = GetComponent<ConfigurableJoint>();

            _startRotation = transform.localRotation;
        }

        private void FixedUpdate()
        {
            _configurableJoint.targetRotation = Quaternion.Inverse(_target.localRotation) * _startRotation;
        }
    }
}