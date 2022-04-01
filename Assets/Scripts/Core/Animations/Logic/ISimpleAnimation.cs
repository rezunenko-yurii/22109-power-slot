using System;

namespace Core.Animations
{
    public interface ISimpleAnimation
    {
        event Action Played;
        void Play();
    }
}