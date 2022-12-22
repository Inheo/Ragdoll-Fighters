using System.Linq;
using UnityEngine;
using Scripts.Data;
using Zenject;
using CodeBase.Infrastructure.Factory;
using CodeBase.StaticData;

public class Level : MonoBehaviour
{
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
    }

    private void Start()
    {
        SubscribeEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _levelStartButton.OnClick += StartLevel;
    }

    private void UnsubscribeEvents()
    {
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