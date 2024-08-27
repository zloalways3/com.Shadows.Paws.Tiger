using UnityEngine.Events;

public class ToggleUISFX : ToggleListenerBase
{
    protected override UnityAction Listener => () => GlobalSFXInfo.TryPlayClick();
}