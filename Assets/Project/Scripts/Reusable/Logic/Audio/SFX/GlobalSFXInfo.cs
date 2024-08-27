using System;
using UnityEngine;

public class GlobalSFXInfo : MonoBehaviour
{
    public static event Action<bool> Toggled;

    [SerializeField] private ClickSFX _click;
    private static ClickSFX _clickStatic;

    public static bool Enabled { get; private set; }
    public static string SaveKey => $"{nameof(GlobalSFXInfo)}_Enabled";

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

    public static bool TryPlayClick() => _clickStatic.TryPlayClick();

    private void Awake()
    {
        var sfxs = FindObjectsOfType<GlobalSFXInfo>();

        foreach(var sfx in sfxs)
            if (sfx != this)
                Destroy(sfx.gameObject);

        DontDestroyOnLoad(gameObject);
        _clickStatic = _click;

        var enabled = PlayerPrefs.GetInt(SaveKey, 1) == 1;

        if (enabled) Enable();
        else Disable();
    }
}