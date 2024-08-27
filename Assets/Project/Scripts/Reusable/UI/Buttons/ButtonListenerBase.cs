using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonListenerBase : UIElementListenerBase
{
    protected Button Button { get; private set; }

    private void Init() => Button = GetComponent<Button>();

    protected override void Subscribe() => Button.onClick.AddListener(Listener);
}