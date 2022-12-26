using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private string _currentScene;

    public event Action OnSceneLoaded;

    private IStartCoroutine _coroutineStarter;

    public SceneLoader(IStartCoroutine coroutineStarter)
    {
        _coroutineStarter = coroutineStarter;
    }

    public void Load(string name)
    {
        if (!string.IsNullOrEmpty(_currentScene))
        {
            SceneManager.UnloadSceneAsync(_currentScene, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        }

        _currentScene = name;
        _coroutineStarter.StartCoroutine(LoadScene(_currentScene));
    }

    public void LoadAsync(string name, Action onLoaded = null) => 
        _coroutineStarter.StartCoroutine(LoadSceneAsync(name, onLoaded));

    private IEnumerator LoadScene(string sceneName)
    {
        SceneManager.sceneLoaded += SceneLoaded;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        yield return null;

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }

    private IEnumerator LoadSceneAsync(string name, Action onLoaded = null)
    {
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

        while (!waitNextScene.isDone)
            yield return null;

        onLoaded?.Invoke();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= SceneLoaded;
        OnSceneLoaded?.Invoke();
    }
}