using System;
using UnityEngine;

public class Win : MonoBehaviour
{
    public static event Action GameOvered;

    [SerializeField] private StopWatch _stopwatch;

    private void Awake() => MatchFind.AllSolved += WinGame;

    private void WinGame()
    {
        _stopwatch.TryStopTime();
        GameOvered?.Invoke();
    }

    private void OnDestroy() => MatchFind.AllSolved -= WinGame;
}