using System.Linq;
using UnityEngine;
using Scripts.Data;
using Zenject;

public class Level : MonoBehaviour
{
    private PlayerFactory _playerFactory;
    private EnemyFactory _enemyFactory;

    private Player _player;
    private Enemy _enemy;

    public event System.Action OnLevelFinish;
    public event System.Action OnLevelFail;

    public bool IsLevelEnd { get; private set; }

    public static Level Instance { get; private set; }

    [Inject]
    public void Construct(PlayerFactory playerFactory, EnemyFactory enemyFactory)
    {
        _playerFactory = playerFactory;
        _enemyFactory = enemyFactory;
    }

    private void Awake()
    {
        Instance = this;
        IsLevelEnd = false;

        CreateUnits();
        SubscribeEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void CreateUnits()
    {
        _player = _playerFactory.Create();
        _enemy = _enemyFactory.Create();
    }

    private void SubscribeEvents()
    {
        _player.OnDeath += Fail;
        _enemy.OnDeath += Win;
    }

    private void UnsubscribeEvents()
    {
    }

    private void Win()
    {
        IsLevelEnd = true;
        OnLevelFinish?.Invoke();
    }

    private void Fail()
    {
        IsLevelEnd = true;
        OnLevelFail?.Invoke();
    }
}