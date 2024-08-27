#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

public class SceneNames
{
    public static IReadOnlyCollection<string> GetNames()
    {
        var names = EditorBuildSettings.scenes.Select(scene =>
        Path.GetFileNameWithoutExtension(scene.path)).ToArray();

        if (names.Length == 0) throw new Exception("Add scenes to \"Scenes in Build\"");

        return names;
    }
}
#endif