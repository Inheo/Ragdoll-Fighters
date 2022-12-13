using System.Linq;
using UnityEngine;
using Scripts.Data;
using Zenject;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;

public class Level : MonoBehaviour
{
    [Inject] private IGameFactory _factory;
    private LevelStartButton _levelStartButton;

    private UnitDeath _player;
    private UnitDeath _enemy;

    public event System.Action OnLevelFinish;
    public event System.Action OnLevelFail;

    public bool IsLevelEnd { get; private set; }

    public static Level Instance { get; private set; }

    [Inject]
    public void Construct(LevelStartButton levelStartButton)
    {
        IsLevelEnd = true;

        _levelStartButton = levelStartButton;
    }

    private void Awake()
    {
        Instance = this;

        GetUnits();
        SubscribeEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void GetUnits()
    {
        _player = _factory.Player.GetComponentInChildren<UnitDeath>();
        _enemy = _factory.Enemy.GetComponentInChildren<UnitDeath>();
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