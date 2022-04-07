using System.Collections.Generic;
using System.Linq;
using Core.Popups;
using UI;
using UnityEngine;
using Zenject;

namespace Core.GameScreens
{
    public class ScreensManager : UIObjectsManager<GameScreen, GameScreens>
    {
        [Inject] private PopupsManager _popupsManager;

        public GameScreen Current { get; private set; }
        private string _next;
        private Stack<UIObject> _stack = new Stack<UIObject>();
        private bool _canShow = true;

        public override void Show(string id)
        {
            if (!_canShow)
            {
                return;
            }
            
            _popupsManager.TryHideLast();

            if (Current == null)
            {
                base.Show(id);
            }
            else if (!Current.Id.Equals(id))
            {
                _next = id;
                _canShow = false;
                Hide(Current);
            }
            
        }

        protected override void OnShown(UIObject uiObject)
        {
            base.OnShown(uiObject);

            Current = (GameScreen) uiObject;
            _next = null;
            _canShow = true;

            var last = _stack.Count > 0 ? _stack.First() : null;
            if (last == null || !last.Equals(uiObject))
            {
                _stack.Push(uiObject);
            }
        }

        protected override void OnHidden(UIObject uiObject)
        {
            base.OnHidden(uiObject);

            Current = null;

            if (_next != null)
            {
                Debug.Log($"Hidden screen {uiObject.Id} / try show {_next}");
                base.Show(_next);
            }
        }

        public void ShowPrevious()
        {
            if (_stack.Count > 1)
            {
                _stack.Pop();
                var last = _stack.First();
                Show(last.Id);
            }
        }
    }
}

