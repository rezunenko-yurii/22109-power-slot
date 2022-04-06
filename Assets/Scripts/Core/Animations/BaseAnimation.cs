using System;
using NSTools.Core;
using UnityEngine;

namespace Core.Animations
{
    public abstract class BaseAnimation : AdvancedMonoBehaviour, IAnimation
    {
        public event Action<IAnimation> Done;

        [field: SerializeField] public float Delay { get; private set; } = 0;
        [field: SerializeField] public float Duration { get; private set; } = 1;
        [field: SerializeField] public AnimationCurve Ease { get; private set; }

        public bool IsPlaying { get; protected set; }
        protected EZ.EZQueue Ez;

        public virtual void Play()
        {
            //Debug.Log($"{GetType()} {nameof(Play)}");
            IsPlaying = true;
            SetStart();
            CreateTween();
        }

        public virtual void PlayImmediate()
        {
            //Debug.Log($"{GetType()} {nameof(PlayImmediate)}");
            SetEnd();
            OnDone();
        }
        
        protected abstract void SetStart();
        protected abstract void SetEnd();
        protected abstract void CreateTween();
        
        protected void OnDone()
        {
            //Debug.Log($"{GetType()} {nameof(OnDone)}");
            
            IsPlaying = false;
            Ez?.Kill();
            Done?.Invoke(this);
        }
        
        public void Stop()
        {
            Ez.Kill();
        }
    }
}