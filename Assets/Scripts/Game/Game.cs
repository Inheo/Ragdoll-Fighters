using Scripts.Data;
using UnityEngine;

public class Game : MonoBehaviour, IStartCoroutine
{
    private const string GAME_PARAMETER = "Game";

    [SerializeField] private FadePanel _winPanel;
    [SerializeField] private FadePanel _failPanel;

    private SceneLoader _sceneLoader;

    public event System.Action<int> OnStartLevel;
    public event System.Action<int> OnFinishLevel;
    public event System.Action<int> OnFailevel;

    private void Awake()
    {
        _sceneLoader = new SceneLoader(this);
    }

    private void Start()
    {
        StartLevel();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void StartLevel()
    {
        OnStartLevel?.Invoke(PlayerProgress.GetData().Level + 1);
        _winPanel.Hide(true);
        _failPanel.Hide(true);

        _sceneLoader.OnSceneLoaded += SceneLoaded;

        _sceneLoader.TryLoadLevel(GAME_PARAMETER);
    }

    private void SceneLoaded()
    {
        _sceneLoader.OnSceneLoaded -= SceneLoaded;
        Subscribe();
    }

    private void Subscribe()
    {
        Level.Instance.OnLevelFinish += ShowWinPanel;
        Level.Instance.OnLevelFail += ShowFailPanel;
    }

    private void Unsubscribe()
    {
        Level.Instance.OnLevelFinish -= ShowWinPanel;
        Level.Instance.OnLevelFail -= ShowFailPanel;
    }

    private void ShowWinPanel()
    {
        OnFinishLevel?.Invoke(PlayerProgress.GetData().Level);
        _winPanel.Show();
    }

    private void ShowFailPanel()
    {
        OnFailevel?.Invoke(PlayerProgress.GetData().Level + 1);
        _failPanel.Show();
    }

    public void RestartGame()
    {
        Unsubscribe();
        StartLevel();
    }
}