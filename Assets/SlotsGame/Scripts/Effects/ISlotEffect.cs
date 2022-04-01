using System;

namespace SlotsGame.Scripts.Effects
{
    public interface ISlotEffect
    {
        public event Action Showed;
        public event Action Hidden;
        public event Action Played;
        
        public void Show();
        public void Hide();
        public void Play();
    }
}