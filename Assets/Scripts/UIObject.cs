using System;
using Core;
using Core.CustomTimeline.Base;
using UnityEngine;
using UnityEngine.Playables;

namespace UI
{
    public abstract class UIObject : AdvancedMonoBehaviour, IUIObject
    {
        public event Action<UIObject> Shown;
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
            ChangeUserInputState(false);
            Director.stopped += OnShown;
            Director.Play();
        }
        
        [ContextMenu("Hide")]
        public virtual void Hide()
        {
            ChangeUserInputState(false);
            Director.stopped += OnHidden;
            StartCoroutine(Director.Reverse());
        }
        
        protected virtual void OnShown(PlayableDirector obj)
        {
            ChangeUserInputState(true);
            Director.stopped -= OnShown;
            
            Shown?.Invoke(this);
        }
        
        protected virtual void OnHidden(PlayableDirector obj)
        {
            ChangeUserInputState(true);
            Director.stopped -= OnHidden;
            
            Hidden?.Invoke(this);
        }

        private void ChangeUserInputState(bool value)
        {
            if (canvasGroup != null)
            {
                canvasGroup.interactable = value;
            }
        }
    }
}