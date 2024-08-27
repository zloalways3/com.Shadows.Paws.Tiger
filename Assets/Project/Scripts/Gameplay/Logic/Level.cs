using System;

public static class Level
{
    private const string GetAccessSceneSceneName = "Gameplay";
    private const string SetAccessSceneSceneName = "Menu";
    private const int MaxValue = 12;

    private static int _value;

    public static bool IsLastLevel => _value == MaxValue;

    public static bool TryGetLevel(out int level)
    {
        level = default;
        if (!IsGetAccessScene) return false;

        level = _value;

        return true;
    }

    public static bool TrySetLevel(int level)
    {
        if (!IsSetAccessScene) return false;
        if (level <= (int)default || level > MaxValue) throw new ArgumentOutOfRangeException();

        _value = level;

        return true;
    }

    public static bool TrySetNextLevel()
    {
        if (!IsGetAccessScene) return false;
        if (_value == MaxValue) return false;

        _value++;

        return true;
    }

    private static bool IsGetAccessScene => SceneCheck.CompareActiveSceneName(GetAccessSceneSceneName);
    private static bool IsSetAccessScene => SceneCheck.CompareActiveSceneName(SetAccessSceneSceneName);
}