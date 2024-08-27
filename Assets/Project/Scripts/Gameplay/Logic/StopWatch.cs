using System;
using System.Threading.Tasks;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    private const int StepInMilliseconds = 1000;

    public event Action<int> Updated;

    private bool _started;

    public int Time { get; private set; }

    public bool TryStartTime()
    {
        if (_started) return false;

        _started = true;
        StartTime();

        return true;
    }

    public bool TryStopTime()
    {
        if (!_started) return false;

        _started = false;

        return true;
    }

    private void Start() => TryStartTime();

    private async void StartTime()
    {
        while (_started)
        {
            await Task.Delay(StepInMilliseconds);
            if (!_started) return;
            Time++;
            Updated?.Invoke(Time);
        }
    }
}