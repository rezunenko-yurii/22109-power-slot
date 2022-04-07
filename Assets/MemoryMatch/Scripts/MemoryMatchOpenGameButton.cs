using Core.Buttons;
using Core.Popups;
using Lives;
using MemoryMatch.Scripts;
using UnityEngine;
using Zenject;

namespace MemoryMatch
{
    public class MemoryMatchOpenGameButton : ShowScreenButton
    {
        [Inject] private LevelsManager _levelsManager;
        [Inject] private LivesManager _livesManager;
        [Inject] private PopupsManager _popupsManager;

        [SerializeField] private string _popupId;
        protected override void OnClick()
        {
            var index = transform.GetSiblingIndex();
            _levelsManager.SetCurrent(index + 1);
            
            if (_livesManager.ActiveLivesAmount > 0)
            {
                base.OnClick();
            }
            else
            {
                _popupsManager.Show(_popupId);
            }
        }
    }
}