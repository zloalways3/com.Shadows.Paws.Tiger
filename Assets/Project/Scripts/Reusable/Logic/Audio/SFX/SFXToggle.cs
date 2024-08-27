using UnityEngine;
using UnityEngine.Events;

public class SFXToggle : ToggleListenerBase
{
    protected override UnityAction<bool> BoolListener => (value) =>
    {
        if (value) GlobalSFXInfo.Enable();
        else GlobalSFXInfo.Disable();
    };

    private void Init() => Toggle.isOn =
        PlayerPrefs.GetInt(GlobalSFXInfo.SaveKey, 1) == 1;
}