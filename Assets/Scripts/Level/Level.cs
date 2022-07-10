using System.Linq;
using UnityEngine;
using Scripts.Data;

public class Level : MonoBehaviour
{
    public event System.Action OnLevelFinish;
    public event System.Action OnLevelFail;

    public bool IsLevelEnd { get; private set; }

    public static Level Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IsLevelEnd = false;
        SubscribeEvents();
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