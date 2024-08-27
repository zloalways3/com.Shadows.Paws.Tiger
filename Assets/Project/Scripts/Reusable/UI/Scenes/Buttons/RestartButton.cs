using UnityEngine.Events;

public class RestartButton : ButtonListenerBase
{
    protected override UnityAction Listener => () => SceneLoader.RestartScene();
}