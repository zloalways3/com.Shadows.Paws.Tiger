public class LevelTextView : TextView<int>
{
    private const string AccessedSceneName = "Gameplay";

    private void Init()
    {
        if (!SceneCheck.CompareActiveSceneName(AccessedSceneName)) return;
        if (!Level.TryGetLevel(out var level)) return;

        UpdateText(level);
    }
}