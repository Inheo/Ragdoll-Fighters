using UnityEngine;

[System.Serializable]
public class MovementSettings
{
    [SerializeField] private float _speed;

    public float Speed => _speed;

    public MovementSettings(float speed)
    {
        _speed = speed;
    }
}