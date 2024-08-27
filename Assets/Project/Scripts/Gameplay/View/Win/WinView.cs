using UnityEngine;

public class WinView : MonoBehaviour
{
    [SerializeField] private GameObject _view;

    private void Awake() => Win.GameOvered += Show;
    private void Show() => _view.SetActive(true);
    private void OnDestroy() => Win.GameOvered -= Show;
}