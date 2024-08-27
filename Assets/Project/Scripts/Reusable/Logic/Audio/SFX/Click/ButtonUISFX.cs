using UnityEngine.Events;

public class ButtonUISFX : ButtonListenerBase
{
    protected override UnityAction Listener => () => GlobalSFXInfo.TryPlayClick();
}