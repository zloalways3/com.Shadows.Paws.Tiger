using UnityEngine;
using UnityEngine.Events;

public class ExitButton : ButtonListenerBase
{
    protected override UnityAction Listener => Application.Quit;
}