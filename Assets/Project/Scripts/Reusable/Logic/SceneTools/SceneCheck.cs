using UnityEngine.SceneManagement;

public static class SceneCheck
{
    public static bool CompareActiveSceneName(string name) =>
        SceneManager.GetActiveScene().name == name;
}