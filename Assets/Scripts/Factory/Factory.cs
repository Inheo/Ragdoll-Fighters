using UnityEngine;
using System;

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parent;

    public virtual T Create()
    {
        T result = Instantiate(_prefab, _spawnPoint.position, Quaternion.identity, _parent).GetComponentInChildren<T>();

        if(result == null)
            new ArgumentException("Prefab have not nedded type: " + typeof(T));

        return result;
    }
}