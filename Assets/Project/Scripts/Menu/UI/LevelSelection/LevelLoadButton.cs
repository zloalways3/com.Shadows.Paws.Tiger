using UnityEngine;
using UnityEngine.Events;

public class LevelLoadButton : ButtonListenerBase
{
    [SerializeField] [Min(1)] private int _level = 1;
    
    protected override UnityAction Listener =>
        () => LevelLoader.TryLoad(_level);
}