public abstract class MusicBase : AudioBase
{
    protected abstract bool LoopEnabled { get; }

    public bool TryPlay()
    {
        if (!GlobalMusicInfo.Enabled) return false;

        Source.Play();
        return true;
    }

    private void Init()
    {
        Source.playOnAwake = false;
        Source.loop = LoopEnabled;

        GlobalMusicInfo.Toggled += Toggle;
    }

    private void Toggle(bool value) => Source.mute = !value;
    private void Deinit() => GlobalMusicInfo.Toggled -= Toggle;
}