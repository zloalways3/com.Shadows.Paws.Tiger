using UnityEngine.Events;

public class NextLevelButton : ButtonListenerBase
{
    protected override UnityAction Listener => LoadNextLevel;

    private void Init()
    {
        if (Level.IsLastLevel) Destroy(gameObject);
    }

    private void LoadNextLevel()
    {
        if (!Level.TrySetNextLevel()) return;

        SceneLoader.RestartScene();
    }
}