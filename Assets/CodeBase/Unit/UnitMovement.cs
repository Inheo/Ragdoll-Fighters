using CodeBase.Unit;
using CodeBase.Unit.Interfaces;
using UnityEngine;
using Zenject;

namespace CodeBase.Unit
{
    [RequireComponent(typeof(Rigidbody))]
    public class UnitMovement : MonoBehaviour
    {
        public float Speed;

        private Rigidbody _rigidbody;
        [Inject] private AnimatorTransition _animatorTransition;
        [Inject] private ICanActionable _canActionable;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void Update()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);

            if (_canActionable.IsCanAction() == false)
                Stop();
        }

        protected void Move(Vector2 direction)
        {
            if (_canActionable.IsCanAction() == false)
                return;

            _rigidbody.velocity = Vector3.right * direction * Speed;

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
}