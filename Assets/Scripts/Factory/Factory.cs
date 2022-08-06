using UnityEngine;

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parent;

    public virtual T Create()
    {
        return Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, _parent);
    }
}