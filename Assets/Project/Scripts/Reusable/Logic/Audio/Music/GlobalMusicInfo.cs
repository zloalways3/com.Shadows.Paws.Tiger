using System;
using UnityEngine;

public class GlobalMusicInfo : MonoBehaviour
{
    public static event Action<bool> Toggled;

    [SerializeField] private BackgroundMusic _backgroundMusic;
    private static BackgroundMusic _backgroundMusicStatic;

    public static bool Enabled { get; private set; }
    public static string SaveKey => $"{nameof(GlobalMusicInfo)}_Enabled";

    public static void Enable()
    {
        Toggled?.Invoke(Enabled = true);
        PlayerPrefs.SetInt(SaveKey, 1);
    }

    public static void Disable()
    {
        Toggled?.Invoke(Enabled = false);
        PlayerPrefs.SetInt(SaveKey, 0);
    }

    public static bool TryPlayBackgroundMusic() => _backgroundMusicStatic.TryPlay();

    private void Awake()
    {
        var musics = FindObjectsOfType<GlobalMusicInfo>();

        foreach (var music in musics)
            if (music != this)
                Destroy(music.gameObject);

        DontDestroyOnLoad(gameObject);

        _backgroundMusicStatic = _backgroundMusic;

        var enabled = PlayerPrefs.GetInt(SaveKey, 1) == 1;

        if (enabled) Enable();
        else Disable();
    }
}