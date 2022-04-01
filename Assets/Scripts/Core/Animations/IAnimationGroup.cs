using System;

namespace Core.Animations
{
    public interface IAnimationGroup
    {
        event Action Done;
        
        void TryPlay();
        void TryPlayImmediate();
        void Stop();

        bool IsPlaying { get; }
    }
}