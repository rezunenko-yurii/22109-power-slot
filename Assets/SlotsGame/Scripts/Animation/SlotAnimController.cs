using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace SlotsGame.Scripts.Animation
{
    public abstract class SlotAnimController : AdvancedMonoBehaviour
    {
        public event Action OnSpinOver;
        
        [SerializeField] private BaseSimpleAnimation simpleAnimation;
        
        [SerializeField] protected int Counter;
        [SerializeField] protected int Count;
        protected List<SlotAnimController> Controllers;

        protected override void Initialize()
        {
            base.Initialize();
            
            InitControllers();
            if (simpleAnimation != null)
            {
                Count++;
            }
        }

        protected override void AddListeners()
        {
            base.AddListeners();
            SubscribeOnSpinOver();
            SubscribeToAnimationPlayed();
        }

        protected override void RemoveListeners()
        {
            base.RemoveListeners();
            Unsubscribe();
        }
        
        private void Unsubscribe()
        {
            foreach (var controller in Controllers)
            {
                controller.Stop();
                controller.OnSpinOver -= OnAnimOver;
            }
            
            if (simpleAnimation != null)
            {
                simpleAnimation.Played -= OnAnimOver;
            }
            
            OnSpinOver = null;

            //Counter = 0;
            //Count = 0;
        }

        protected virtual void InitControllers()
        {
            Controllers = GetControllers();
            Count = Controllers.Count;
        }

        private void SubscribeOnSpinOver()
        {
            foreach (var controller in Controllers)
            {
                controller.OnSpinOver += OnAnimOver;
            }
        }
        
        private void SubscribeToAnimationPlayed()
        {
            if (simpleAnimation != null)
            {
                simpleAnimation.Played += OnAnimOver;
            }
        }

        public virtual void Play()
        {
            foreach (var controller in Controllers)
            {
                controller.Play();
            }
            
            simpleAnimation?.Play();
        }

        public void Stop()
        {
            foreach (var controller in Controllers)
            {
                controller.Stop();
            }
            
            simpleAnimation?.Stop();
        }

        protected virtual void OnAnimOver()
        {
            Counter++;

            if (Counter == Count)
            {
                Counter = 0;
                OnSpinOver?.Invoke(); 
            }
        }
        
        protected abstract List<SlotAnimController> GetControllers();
        
    }
}