using System;
using UnityEngine;

namespace SlotsGame.Scripts.Effects
{
    public class FreeSpinsFX : MonoBehaviour, ISlotEffect
    {
        public event Action Showed;
        public event Action Hidden;
        public event Action Played;
        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }
    }
}