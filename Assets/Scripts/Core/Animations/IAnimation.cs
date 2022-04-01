using System;

namespace Core.Animations
{
    public interface IAnimation
    {
        event Action<IAnimation> Done;

        float Delay { get; }
        float Duration { get; }

        void Play();
        void PlayImmediate();
        
        void Stop();
        bool IsPlaying { get; }
    }
}