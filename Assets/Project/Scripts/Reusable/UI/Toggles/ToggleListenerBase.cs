using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class ToggleListenerBase : UIElementListenerBase
{
    protected Toggle Toggle { get; private set; }

    protected virtual UnityAction<bool> BoolListener { get; }

    private void Init() => Toggle = GetComponent<Toggle>();

    protected override void Subscribe()
    {
        Toggle.onValueChanged.AddListener((_) => Listener?.Invoke());
        Toggle.onValueChanged.AddListener((value) => BoolListener?.Invoke(value));
    }
}