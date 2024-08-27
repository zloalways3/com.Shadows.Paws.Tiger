using System;
using UnityEngine;

public class MatchFind : MonoBehaviour
{
    public const int WinCount = 12;

    public static event Action AllSolved;

    private Item _lastItem;

    public static int SolvedCount { get; private set; }
    private static bool IsAllSolved => SolvedCount == WinCount;

    private void Awake()
    {
        SolvedCount = default;
        _lastItem = default;

        Item.Selected += CheckMatches;
    }

    private void CheckMatches(Item item)
    {
        if (IsAllSolved) return;
        if (item.IsSolved) return;

        if(_lastItem == null)
        {
            _lastItem = item;
            return;
        }

        if (_lastItem.Type == item.Type)
        {
            Add(_lastItem);
            Add(item);
        }
        else
        {
            _lastItem.ForceDeselect();
            item.ForceDeselect();
        }

        _lastItem = null;

        if (SolvedCount != WinCount) return;
        AllSolved?.Invoke();
    }

    private void Add(Item item)
    {
        item.TrySolve();
        SolvedCount++;
    }

    private void OnDestroy() => Item.Selected -= CheckMatches;
}