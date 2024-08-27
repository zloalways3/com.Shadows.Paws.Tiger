using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(AudioSource))]
public abstract class AudioBase : MonoBehaviour
{
    protected AudioSource Source { get; private set; }

    private UnityMethodReplace _initializer;
    private UnityMethodReplace _deinitializer;

    private void Awake()
    {
        Source = GetComponent<AudioSource>();

        Source.mute = false;

        _initializer = new UnityMethodReplace(typeof(AudioBase), nameof(Init), nameof(Awake), nameof(Start));
        _deinitializer = new UnityMethodReplace(typeof(AudioBase), nameof(Deinit), nameof(OnDestroy));

        _initializer.CheckOldMethods(this);
        _deinitializer.CheckOldMethods(this);

        _initializer.InvokeAll(this);
    }

    private void Start() { }
    private void Init() { }
    private void Deinit() { }

    private void OnDestroy() => _deinitializer.InvokeAll(this);
}