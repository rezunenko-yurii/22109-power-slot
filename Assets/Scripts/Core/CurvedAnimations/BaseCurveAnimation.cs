using System;
using System.Collections;
using UnityEngine;

namespace Core.CurvedAnimations
{
    public abstract class BaseCurveAnimation : MonoBehaviour, ICurveAnimation
    {
        protected const float WaitTime = 0.01f;

        public abstract event Action Started;
        public abstract event Action Ended;
        
        [field: SerializeField] public float Duration { get; protected set; }
        [field: SerializeField] public float Speed { get; protected set; }
        [field: SerializeField] public AnimationCurve Curve { get; protected set; }

        public float ExpiredTime { get; private set; }
        public float Progress => ExpiredTime / Duration;
        public bool CanPlay { get; private set; }
        public bool InProgress => ExpiredTime < Duration;
        public float Value => Curve.Evaluate(Progress) * Speed;

        private Coroutine _coroutine;
        
        protected void IncreaseExpiredTime() => ExpiredTime += WaitTime;

        private void Start()
        {
            Reset();
        }

        public void TryPlay()
        {
            if (CanPlay)
            {
                CanPlay = false;
                _coroutine = StartCoroutine(Play());
            }
            else
            {
                Debug.Log("Can`t play animation. It`s already playing");
            }
        }

        private IEnumerator Play()
        {
            OnStarted();
            
            while (InProgress)
            {
                IncreaseExpiredTime();
                Animate();
                
                yield return new WaitForSeconds(WaitTime);
            }
            
            Reset();
            OnEnded();
        }

        protected abstract void Animate();

        protected abstract void OnStarted();
        protected abstract void OnEnded();
        protected abstract void RemoveSubscribers();

        protected virtual void Reset()
        {
            CanPlay = true;
            ExpiredTime = 0f;
        }

        private void OnDestroy()
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
            
            RemoveSubscribers();
        }
    }
}