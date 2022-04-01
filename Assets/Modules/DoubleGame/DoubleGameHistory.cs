using System;
using DoubleGameLib;
using UnityEngine;
using UnityEngine.UI;

public class DoubleGameHistory : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    [SerializeField] private Sprite empty;
    [SerializeField] private Sprite red;
    [SerializeField] private Sprite blue;

    public void Add(DoubleCardType type, int attempt)
    {
        Sprite sprite = GetSprite(type);

        //_images[attempt].enabled = true;
        _images[attempt].sprite = sprite;
        _images[attempt].SetNativeSize();
    }

    private Sprite GetSprite(DoubleCardType type)
    {
        if (type.Equals(DoubleCardType.Red))
        {
            return red;
        }
        else
        {
            return blue;
        }
    }

    public void Reset()
    {
        foreach (var image in _images)
        {
            image.sprite = empty;
            //image.enabled = false;
        }
    }
}
