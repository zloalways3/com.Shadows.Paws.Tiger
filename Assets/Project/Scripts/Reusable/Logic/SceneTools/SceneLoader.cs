using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private const int MillisecondsInSecond = 1000;
    private const float NotifyRate = 0.5f;

    public static event Action<float> ProgressUpdated;
    public static event Action SceneLoaded;

    private static float _lastProgressValue;

    public static void RestartScene()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        Load(sceneName);
    }

    public static async void Load(string sceneName)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            var progress = operation.progress;

            if (progress != _lastProgressValue) ProgressUpdated?.Invoke(progress);
            _lastProgressValue = progress;

            var delay = Mathf.RoundToInt(NotifyRate * MillisecondsInSecond);
            await Task.Delay(delay);
        }

        SceneLoaded?.Invoke();
    }
}