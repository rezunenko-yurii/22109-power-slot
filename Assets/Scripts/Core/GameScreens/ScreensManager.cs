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
        
        //private string _nextId;
        private (string, string) scrs;
        
        public override void Show(string id)
        {
            if (scrs.Item2 != null)
            {
                return;
            }
            
            _popupsManager.TryHideLast();
            string currentId = GetLastId();
            
            if (string.IsNullOrEmpty(currentId))
            {
                base.Show(id);
            }
            else if (!currentId.Equals(id))
            {
                scrs = (currentId, id);
                Hide(currentId);
            }
            
            
            /*string currentId = GetLastId();
            if (currentId == null )
            {
                Debug.Log($"Show screen {id}");
                _nextId = null;
                base.Show(id);
            }
            else if (!currentId.Equals(id))
            {
                Debug.Log($"Show new screen {id} / hide {currentId}");
                _nextId = id;
                Hide(currentId);
            }*/
        }

        protected override void OnHidden(UIObject uiObject)
        {
            base.OnHidden(uiObject);
            string next = scrs.Item2;
            if (next != null)
            {
                Debug.Log($"Hidden screen {uiObject.Id} / try show {next}");
                scrs = (null, null);
                base.Show(next);
                //_nextId = null;
            }
        }

        protected override void AddToActive(GameScreen uiObject)
        {
            base.AddToActive(uiObject);
            Current = uiObject;
        }
    }
}

