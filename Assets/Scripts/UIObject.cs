using System;
using Core;
using Core.CustomTimeline;
using Core.CustomTimeline.Base;
using UnityEngine;
using UnityEngine.Playables;

namespace UI
{
    public abstract class UIObject : AdvancedMonoBehaviour, IUIObject
    {
        public event Action<UIObject> Showed;
        public event Action<UIObject> Hidden;

        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] protected PlayableDirector Director { get; private set; }

        protected CanvasGroup canvasGroup;

        protected override void Awake()
        {
            base.Awake();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        [ContextMenu("Show")]
        public virtual void Show()
        {
            ChangeCanvasGroupInteractable(false);
            Director.stopped += OnShowed;
            Director.Play();
        }
        
        [ContextMenu("Hide")]
        public virtual void Hide()
        {
            ChangeCanvasGroupInteractable(false);
            Director.stopped += OnHidden;
            StartCoroutine(Director.Reverse());
            //DisappearAnimationGroup?.TryPlay();
        }
        
        protected virtual void OnShowed(PlayableDirector obj)
        {
            ChangeCanvasGroupInteractable(true);
            Director.stopped -= OnShowed;
            Showed?.Invoke(this);
        }
        
        protected virtual void OnHidden(PlayableDirector obj)
        {
            ChangeCanvasGroupInteractable(true);
            Director.stopped -= OnHidden;
            Hidden?.Invoke(this);
        }

        private void ChangeCanvasGroupInteractable(bool value)
        {
            //canvasGroup.interactable = value;
        }
    }
}