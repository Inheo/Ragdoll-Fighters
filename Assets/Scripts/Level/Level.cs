using System.Linq;
using UnityEngine;
using Scripts.Data;
using Zenject;

public class Level : MonoBehaviour
{
    private PlayerFactory _playerFactory;
    private EnemyFactory _enemyFactory;

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
    }

    private void Start()
    {
        IsLevelEnd = false;
        SubscribeEvents();

        Player player = _playerFactory.Create();
        Enemy enemy = _enemyFactory.Create();

        player.Initialize();
        enemy.Initialize();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }

    private void SubscribeEvents()
    {
    }

    private void UnsubscribeEvents()
    {
    }

    private void CheckWin()
    {
        bool isWin = true;

        if (isWin == true)
        {
            IsLevelEnd = true;

            OnLevelFinish?.Invoke();
        }
    }

    private void Fail()
    {
        IsLevelEnd = true;
        OnLevelFail?.Invoke();
    }
}