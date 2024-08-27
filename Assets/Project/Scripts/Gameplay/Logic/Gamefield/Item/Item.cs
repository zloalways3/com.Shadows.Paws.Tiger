using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static event Action<Item> Selected;

    public event Action Solved;
    public event Action Deselected;

    private bool _isSelected;
    private bool _solved;
    private string _type;

    public bool IsSelected => _isSelected;
    public bool IsSolved => _solved;
    public string Type => _type;

    public void Select()
    {
        _isSelected = true;
        Selected?.Invoke(this);
    }

    public void Deselect() => _isSelected = false;

    public void ForceDeselect()
    {
        Deselect();
        Deselected?.Invoke();
    }

    public bool TrySolve()
    {
        if (_solved) return false;

        _solved = true;
        Solved?.Invoke();
        return true;
    }

    public bool TrySetType(string type)
    {
        if (!string.IsNullOrEmpty(_type)) return false;
        if (string.IsNullOrEmpty(type)) return false;

        _type = type;
        return true;
    }
}