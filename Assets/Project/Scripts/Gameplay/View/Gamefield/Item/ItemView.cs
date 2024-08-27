using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Item))]
[RequireComponent(typeof(Button))]
public class ItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] [Min(0.1f)] private float _animationDuration = 1f;
    [SerializeField] private Ease _ease = Ease.Linear;

    private Item _item;
    private Button _button;
    private Vector3 _defaultSize;

    private bool _animationIsPlaying;

    private void Awake()
    {
        _item = GetComponent<Item>();
        _button = GetComponent<Button>();

        _button.onClick.AddListener(ToggleSelected);
        _defaultSize = _icon.transform.localScale;

        _icon.gameObject.SetActive(true);

        _item.Deselected += ForceDeselect;

        ChangeScale(Vector3.zero, default, null);
    }

    private void Start()
    {
        var sprite = ItemRepository.GetRandomIcon();

        _icon.sprite = sprite;
        _icon.SetNativeSize();
        _item.TrySetType(sprite.name);
    }

    private void OnDestroy() => _item.Deselected -= ForceDeselect;

    private void ToggleSelected()
    {
        if (_item.IsSolved) return;
        if (_animationIsPlaying) return;

        _animationIsPlaying = true;

        if (_item.IsSelected) Deselect();
        else Select();
    }

    private void Select()
    {
        _icon.gameObject.SetActive(true);

        ChangeScale(_defaultSize, _animationDuration, () =>
        {
            _item.Select();
            _animationIsPlaying = false;
        });
    }

    private void Deselect()
    {
        ChangeScale(Vector3.zero, _animationDuration, () =>
        {
            _icon.gameObject.SetActive(false);
            _item.Deselect();
            _animationIsPlaying = false;
        });
    }

    private void ForceDeselect() => ChangeScale(Vector3.zero, _animationDuration, null);

    private void ChangeScale(Vector3 scale, float duration, TweenCallback callback)
    {
        _icon.transform.
            DOScale(scale, duration).
            SetEase(_ease).
            OnComplete(callback);
    }
}