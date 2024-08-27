using UnityEngine;
using UnityEngine.Events;

public class MusicToggle : ToggleListenerBase
{
    protected override UnityAction<bool> BoolListener => (value) =>
    {
        if (value) GlobalMusicInfo.Enable();
        else GlobalMusicInfo.Disable();
    };

    private void Init() => Toggle.isOn =
        PlayerPrefs.GetInt(GlobalMusicInfo.SaveKey, 1) == 1;
}