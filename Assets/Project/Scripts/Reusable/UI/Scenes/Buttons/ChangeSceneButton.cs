using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class ChangeSceneButton : ButtonListenerBase
{
#if UNITY_EDITOR
    [Dropdown(nameof(Names))]
#endif
    [SerializeField] private string _selectedSceneName;

#if UNITY_EDITOR
    private IEnumerable<string> Names => SceneNames.GetNames();
#endif
    protected override UnityAction Listener => () => SceneLoader.Load(_selectedSceneName);
}