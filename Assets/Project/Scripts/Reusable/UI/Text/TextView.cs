using TMPro;
using UnityEngine;

public abstract class TextView<T> : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private string _format = "{0}";

    private UnityMethodReplace _initializer;

    protected virtual T DefaultValue => default;

    protected void UpdateText(T value) => _text.text = string.Format(_format, value);
    protected void UpdateText(T value1, T value2) => _text.text = string.Format(_format, value1, value2);
    protected void UpdateText(T value1, T value2, T value3) => _text.text = string.Format(_format, value1, value2, value3);

    private void Awake()
    {
        _initializer = new UnityMethodReplace(
            typeof(TextView<T>), nameof(Init), nameof(Awake), nameof(Start));
    }

    private void Start()
    {
        _initializer.CheckOldMethods(this);
        _initializer.InvokeAll(this);
    }

    private void Init() { }
}