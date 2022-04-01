using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Animations
{
    public class AnimationGroup : AdvancedMonoBehaviour, IAnimationGroup
    {
        public event Action Done;

        [field: SerializeField] private List<BaseAnimation> animations;
        [field: SerializeField] public bool IsPlaying { get; protected set; }

        private SubscriptionsWatcher subscriptionsWatcher;
        
        protected override void Awake()
        {
            base.Awake();
            subscriptionsWatcher = new SubscriptionsWatcher();
        }
        
        public void TryPlay()
        {
            Debug.Log($"{nameof(AnimationGroup)} {nameof(TryPlay)}");
            
            if (IsPlaying)
            {
                Debug.LogError($"{nameof(AnimationGroup)} {nameof(TryPlay)} attempt to play animation when another one is already playing");
                return;
            }
            
            Play();
        }

        protected void Play()
        {
            Debug.Log($"{nameof(AnimationGroup)} {nameof(Play)}");

            ChangeIsPlaying(true);
            foreach (var anim in animations)
            {
                subscriptionsWatcher.Add();
                anim.Done += OnAnimationDone;
                
                anim.Play();
            }
            
            subscriptionsWatcher.InvokeDoneIfNoneSubscribers();
        }

        private void ChangeIsPlaying(bool value)
        {
            IsPlaying = value;
        }
        
        public void TryPlayImmediate()
        {
            Debug.Log($"{nameof(AnimationGroup)} {nameof(TryPlayImmediate)}");
            
            if (IsPlaying)
            {
                Debug.LogError($"{nameof(AnimationGroup)} {nameof(TryPlayImmediate)} attempt to play animation when another one is already playing");
                return;
            }
            
            PlayImmediate();
        }
        
        private void PlayImmediate()
        {
            Debug.Log($"{nameof(AnimationGroup)} {nameof(PlayImmediate)}");
            
            ChangeIsPlaying(true);
            foreach (var anim in animations)
            {
                subscriptionsWatcher.Add();
                anim.Done += OnAnimationDone;
                
                anim.PlayImmediate();
            }
            
            subscriptionsWatcher.InvokeDoneIfNoneSubscribers();
        }
        
        private void OnAnimationDone(IAnimation anim)
        {
            anim.Done -= OnAnimationDone;
            subscriptionsWatcher.Remove();
        }

        protected virtual void OnDone()
        {
            Debug.Log($"{nameof(AnimationGroup)} {nameof(OnDone)}");
            
            ChangeIsPlaying(false);
            Done?.Invoke();
        }
        
        protected override void AddListeners()
        {
            base.AddListeners();
            subscriptionsWatcher.Done += OnDone;
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            subscriptionsWatcher.Done -= OnDone;
        }

        public void Stop()
        {
            foreach (var anim in animations)
            {
                anim.Stop();
                subscriptionsWatcher.Remove();
            }
        }
    }
}