using UnityEngine;
using System;
using Zenject;

public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _parent;

    [Inject] private DiContainer _diContainer;

    protected virtual T Create()
    {
        T result = _diContainer.InstantiatePrefab(_prefab, _spawnPoint.position, Quaternion.identity, _parent).GetComponentInChildren<T>();

        if(result == null)
            new ArgumentException("Prefab have not nedded type: " + typeof(T));

        return result;
    }
}