using UnityEngine;
using UnityEngine.Events;

public abstract class UIElementListenerBase : MonoBehaviour
{
    protected virtual UnityAction Listener { get; }

    private UnityMethodReplace _initializer;

    private void Awake()
    {
        _initializer = new UnityMethodReplace(typeof(UIElementListenerBase), nameof(Init), nameof(Awake), nameof(Start));

        _initializer.CheckOldMethods(this);
        _initializer.ReversedInvokeAll(this);

        Subscribe();
    }

    protected abstract void Subscribe();

    private void Start() { }
    private void Init() { }
}