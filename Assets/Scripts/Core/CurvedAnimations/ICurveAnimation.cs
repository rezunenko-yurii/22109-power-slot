using UnityEngine;

namespace Core.CurvedAnimations
{
    public interface ICurveAnimation
    {
        float Duration { get; }
        float ExpiredTime { get; }
        float Speed { get; }
        float Progress { get; }
        bool CanPlay { get; }
        bool InProgress { get; }
        float Value { get; }
        AnimationCurve Curve { get; }
        void TryPlay();
    }
}