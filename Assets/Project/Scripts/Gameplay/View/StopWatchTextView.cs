using UnityEngine;

public class StopWatchTextView : TextView<int>
{
    private const int SecondsInMinute = 60;

    [SerializeField] private StopWatch _stopWatch;

    private void Show(int value)
    {
        var minutes = value / SecondsInMinute;
        var seconds = value % SecondsInMinute;

        UpdateText(minutes, seconds);
    }

    private void OnEnable()
    {
        _stopWatch.Updated += Show;
        Show(_stopWatch.Time);
    }

    private void OnDisable() => _stopWatch.Updated -= Show;
}