using System.Linq;
using UnityEngine;
using Scripts.Data;
using Zenject;

public class Level : MonoBehaviour
{
    private PlayerFactory _playerFactory;
    private EnemyFactory _enemyFactory;
    private LevelStartButton _levelStartButton;

    private Player _player;
    private Enemy _enemy;

    public event System.Action OnLevelFinish;
    public event System.Action OnLevelFail;

    public bool IsLevelEnd { get; private set; }

    public static Level Instance { get; private set; }

    [Inject]
    public void Construct(PlayerFactory playerFactory, EnemyFactory enemyFactory, LevelStartButton levelStartButton)
    {
        IsLevelEnd = true;

        _playerFactory = playerFactory;
        _enemyFactory = enemyFactory;

        _levelStartButton = levelStartButton;
    }

    private void Awake()
    {
        Instance = this;

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

        _levelStartButton.OnClick += StartLevel;
    }

    private void UnsubscribeEvents()
    {
        _player.OnDeath -= Fail;
        _enemy.OnDeath -= Win;

        _levelStartButton.OnClick -= StartLevel;
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

    public void StartLevel()
    {
        IsLevelEnd = false;
    }
}