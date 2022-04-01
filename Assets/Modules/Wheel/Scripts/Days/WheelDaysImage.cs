using System;
using UnityEngine;
using UnityEngine.UI;

namespace WheelLib.Days
{
    [Serializable]
    public class WheelDaysImage : IDays
    {
        [SerializeField] private Image _image;
        [SerializeField] private Sprite[] _daysSprites;
        
        public void UpdateCurrentDay(int position)
        {
            _image.sprite = _daysSprites[position];
            _image.SetNativeSize();
        }
    }
}