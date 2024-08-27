public static class LevelLoader
{
    private const string AccessedSceneName = "Menu";
    private const string LevelScene = "Gameplay";

    public static bool TryLoad(int level)
    {
        if (!SceneCheck.CompareActiveSceneName(AccessedSceneName)) return false;
        if (!Level.TrySetLevel(level)) return false;

        SceneLoader.Load(LevelScene);

        return true;
    }
}