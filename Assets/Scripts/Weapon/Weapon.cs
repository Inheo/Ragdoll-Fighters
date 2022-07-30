using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;

    private bool _isActive = false;

    public float Damage => _damage;

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
        if (_isActive == true && other.rigidbody.TryGetComponent(out ITakeDamage takeDamage))
        {
            Deactive();
            takeDamage.TakeDamage(_damage);
        }
    }
}