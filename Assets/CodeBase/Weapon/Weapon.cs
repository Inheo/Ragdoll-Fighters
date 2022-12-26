using CodeBase.Unit.Interfaces;
using UnityEngine;
using UnitBase = CodeBase.Unit.Unit;

namespace CodeBase.Weapon
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _damage = 1f;

        private UnitBase _owner;

        private bool _isActive = false;

        public float Damage => _damage;

        public void Initialize(UnitBase owner)
        {
            _owner = owner;
        }

        public void Active()
        {
            _isActive = true;
        }

        public void Deactive()
        {
            _isActive = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (_isActive == true && other.rigidbody != null && other.rigidbody.TryGetComponent(out ITakeDamage takeDamage) && _owner != takeDamage.Owner)
            {
                Deactive();
                takeDamage.TakeDamage(_damage);
            }
        }
    }
}