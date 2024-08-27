using UnityEngine;
using UnityEngine.UI;

public class SceneLoadBarView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void UpdateView(float value) => _slider.value = value;
    private void OnEnable() => SceneLoader.ProgressUpdated += UpdateView;
    private void OnDisable() => SceneLoader.ProgressUpdated -= UpdateView;
}