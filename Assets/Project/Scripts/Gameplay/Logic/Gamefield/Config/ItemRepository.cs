using System.Collections.Generic;
using UnityEngine;

public class ItemRepository : MonoBehaviour
{
    [SerializeField] private List<Sprite> _icons;

    private static List<Sprite> _doubledIcons;

    private void Awake()
    {
        _doubledIcons = new List<Sprite>();

        foreach(var icon in _icons)
        {
            _doubledIcons.Add(icon);
            _doubledIcons.Add(icon);
        }
    }

    public static Sprite GetRandomIcon()
    {
        var index = Random.Range(0, _doubledIcons.Count);
        var sprite = _doubledIcons[index];
        _doubledIcons.RemoveAt(index);
        return sprite;
    }
}