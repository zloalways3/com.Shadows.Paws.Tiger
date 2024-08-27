public abstract class SFXbase : AudioBase
{
    public bool TryPlayClick()
    {
        if (!GlobalSFXInfo.Enabled) return false;

        Source.Play();
        return true;
    }

    private void Init()
    {
        Source.playOnAwake = false;
        Source.loop = false;

        GlobalSFXInfo.Toggled += Toggle;
    }

    private void Toggle(bool value) => Source.mute = !value;
    private void Deinit() => GlobalSFXInfo.Toggled -= Toggle;
}