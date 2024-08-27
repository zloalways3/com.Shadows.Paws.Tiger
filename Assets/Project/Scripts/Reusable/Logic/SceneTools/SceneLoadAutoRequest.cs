using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class SceneLoadAutoRequest : MonoBehaviour
{
#if UNITY_EDITOR
    [Dropdown(nameof(Names))]
#endif
    [SerializeField] private string _sceneName;

#if UNITY_EDITOR
    private IEnumerable<string> Names => SceneNames.GetNames();
#endif
    private void Start() => SceneLoader.Load(_sceneName);
}